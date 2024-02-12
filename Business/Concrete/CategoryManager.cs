using AutoMapper;
using Business.Abstarct;
using Business.Constants;
using Business.DTOs;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Core.Ultilities.Helpers;
using Core.Ultilities.Responses.Concrete;
using Core.Ultilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Ultilities.Responses.Abstract;
using Business.ValidationRules.FluentValidation.CategoryValidators;

namespace Business.Concrete
{
       public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IProductService _productService;
        private IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository,IMapper mapper,IProductService productService)
        {
            _categoryRepository = categoryRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IResponse> GetByIdAsync(Guid id)
        {
            var category =  await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                return new DataResponse<Category>(category, 200);
            }
            throw new ApiException(404, Messages.NotFound);
        }

        public async Task<IResponse> GetAllAsync()
        {
            var categories =  await _categoryRepository.GetAllAsync();
            return new DataResponse<IEnumerable<Category>>(categories, 200);
        }
        [ValidationAspect(typeof(AddCategoryValidator))]
        public async Task<IResponse> AddAsync(CategoryDTO model)
        {
            var category = _mapper.Map<Category>(model);
            category.CategoryOptions = model.OptionIds.Select(optionid => new CategoryOption()
            {
                CategoryId = category.Id,
            }).ToList();
            category.Slug = SlugHelper.Slugify(model.Name);
            var addedcategory =  await _categoryRepository.AddAsync(category);
            return new DataResponse<Category>(addedcategory, 200, Messages.AddedSuccesfully);
        }
        [ValidationAspect(typeof(UpdateCategoryValidator))]
        public async Task<IResponse> UpdateAsync(CategoryDTO model)
        {
            var category = await _categoryRepository.GetByIdAsync(model.Id);
            if (category != null)
            {
                var updatedcategory = _mapper.Map(model, category);
                updatedcategory.CategoryOptions = model.OptionIds.Select(optionid => new CategoryOption()
                {
                    CategoryId = category.Id,
                }).ToList();
                updatedcategory.Slug = SlugHelper.Slugify(model.Name);
                await _categoryRepository.UpdateAsync(category);
                return new SuccessResponse(200, Messages.UpdatedSuccessfully);
            }
            else
            {
                throw new ApiException(404, Messages.NotFound);
            }
        }

        public async Task<IResponse> RemoveAsync(Guid id)
        {
            var exist = await _categoryRepository.GetByIdAsync(id);
            if (exist != null)
            {
                var product = await _productService.GetProductWithImagesByCategoryIdAsync(id);
                if (product!=null)
                {
                    foreach (var item in product.ProductImages)
                    {
                        FileManager.DeleteFile(item.Image);
                    }
                    FileManager.DeleteFile(product.MainImage);
                }
                await _categoryRepository.RemoveAsync(exist);
                return new SuccessResponse(200, Messages.DeletedSuccessfully);
            }
            throw new ApiException(404, Messages.NotFound);
        }

        public async Task<IResponse> GetCategoriesWithOptionsAsync()
        {
            var categorieswithoptions = await _categoryRepository.GetAllAsync();
            return new DataResponse<IEnumerable<CategoryDTO>?>(_mapper.Map<IEnumerable<CategoryDTO>>(categorieswithoptions), 200);
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Extensions;
using Core.Exceptions;
using Business.Abstarct;
using Business.DTOs;
using Business.Filters;
using Core.Ultilities.Helpers;
using Core.Ultilities.Responses.Concrete;
using Core.Ultilities;
using Core.Ultilities.Responses.Abstract;
using Business.ValidationRules.FluentValidation.ProductValidators;
using LinqKit;
using AutoFilterer.Extensions;
using Core.Ultilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        [ValidationAspect(typeof(AddProductValidator))]
        public async Task<IResponse> AddAsync(ProductDTO model)
        {
            var product = _mapper.Map<Product>(model);
            product.Slug = SlugHelper.Slugify(model.Name);
            product.MainImage = FileManager.SaveFile(FolderNames.Products, model.Image);
            product.ProductOptionValues = new List<ProductOptionValue>();
            foreach (var productoptionvalue in model.OptionValues)
            {
                product.ProductOptionValues.Add(new ProductOptionValue()
                {
                    OptionValueId = productoptionvalue.OptionValueId
                });
            }
            product.ProductImages = new List<ProductImage>();
            foreach (var productimage in model.Images)
            {
                product.ProductImages.Add(new ProductImage()
                {
                    Image = FileManager.SaveFile(FolderNames.Products, productimage)
                });
            }
            await _productRepository.AddAsync(product);
            return new SuccessResponse(200, Messages.AddedSuccesfully);
        }

        [ValidationAspect(typeof(UpdateProductValidator))]
        public async Task<IResponse> UpdateAsync(ProductDTO model)
        {
            var product = await _productRepository.GetWithOptionsAndImagesByProductId(model.Id);
            var updatedproduct = _mapper.Map(model, product);
            if (model.Image != null)
            {
                FileManager.DeleteFile(product.MainImage);
                updatedproduct.MainImage = FileManager.SaveFile(FolderNames.Products, model.Image);
            }
            else
            {
                updatedproduct.MainImage = product.MainImage;
            }
            updatedproduct.Slug = SlugHelper.Slugify(model.Name);
            product.ProductOptionValues = model.OptionValues.Select(pow => new ProductOptionValue()
            {
                OptionValueId = pow.OptionValueId
            }).ToList();
            if (model.Images != null)
            {
                foreach (var productimage in model.Images)
                {
                    product.ProductImages.Add(new ProductImage()
                    {
                        Image = FileManager.SaveFile(FolderNames.Products, productimage)
                    });
                }
            }
            await _productRepository.UpdateAsync(product);
            return new SuccessResponse(200, Messages.UpdatedSuccessfully);
        }

        public async Task<IResponse> RemoveAsync(Guid id)
        {
            var product = await _productRepository.GetProductWithImagesByIdAsync(id);
            if (product != null)
            {
                foreach (var item in product.ProductImages)
                {
                    FileManager.DeleteFile(item.Image);
                }
                FileManager.DeleteFile(product.MainImage);
                await _productRepository.RemoveAsync(product);
            }
            return new SuccessResponse(200, Messages.DeletedSuccessfully);
        }

        public async Task<IResponse> GetAllAdminProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var adminproducts = _mapper.Map<IEnumerable<AdminProductDetailsDTO>>(products);
            return new DataResponse<IEnumerable<AdminProductDetailsDTO>>(adminproducts, 200);
        }

        public async Task<IResponse> GetAdminProduct(Guid productid)
        {
            var product = await _productRepository.GetByIdAsync(productid);
            var adminproduct = _mapper.Map<AdminProductDetailsDTO>(product);
            return new DataResponse<AdminProductDetailsDTO>(adminproduct, 200);
        }

        public async Task<IResponse> GetProductDetail(string slug)
        {
            var product = await _productRepository.GetAllAsync(x => x.Slug == slug);
            var productdetail = _mapper.Map<ProductDetailDTO?>(product);
            if (productdetail == null)
            {
                throw new ApiException(404, Messages.NotFound);
            }
            return new DataResponse<ProductDetailDTO>(productdetail, 200);
        }

        public IResponse GetProductsWithImage(ProductFilter filter)
        {
            var productswithimages = GetProductsFilter(filter);
            var pagedproductswithimages = productswithimages.ApplyPaging(filter.Page, filter.PageSize);
            return new PagedDataResponse<IQueryable<ProductWithMainImageDTO>>(pagedproductswithimages, 200, productswithimages.Count());
        }

        public async Task<IResponse> GetLast10ProductsWithImage()
        {
            var last10productswithimages = await GetLast10ProductsList();
            return new DataResponse<IEnumerable<ProductWithMainImageDTO>>(last10productswithimages, 200);
        }

        public async Task<Product> GetProductWithImagesByCategoryIdAsync(Guid categoryid)
        {
            return await _productRepository.GetProductWithImagesByCategoryIdAsync(categoryid);
        }
        private IQueryable<ProductWithMainImageDTO> GetProductsFilter(ProductFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Search))
            {
                var terms = filter.Search.Split(" ");
                return _productRepository.GetAll().Where(u => terms.All(m => u.Name.Contains(m) || u.Slug.Contains(m) || u.Description.Contains(m))).AsQueryable().ApplyFilter(filter).Select(product => new ProductWithMainImageDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.ToString("N"),
                    BrandName = product.Brand.Name,
                    Slug = product.Slug,
                    MainImage = product.MainImage,
                    RatingAverage = product.Reviews.Select(review => (int?)(review.RatingValue)).Cast<decimal>().Average()
                }).AsQueryable();
            }
            else if (filter.ProductOptionValues != null)
            {
                var predicate = PredicateBuilder.New<Product>();
                foreach (string value in filter.ProductOptionValues.OptionValue.Value)
                    predicate = predicate.And((x => x.ProductOptionValues.Any(x => x.OptionValue.Value == value)));

                return _productRepository.GetAll().Where(predicate).AsQueryable().ApplyFilter(filter).Select(product => new ProductWithMainImageDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.ToString("N"),
                    BrandName = product.Brand.Name,
                    Slug = product.Slug,
                    MainImage = product.MainImage,
                    RatingAverage = product.Reviews.Select(review => (int?)(review.RatingValue)).Cast<decimal>().Average()
                }).AsQueryable();
            }
            else
            {
                return _productRepository.GetAll().AsQueryable().ApplyFilter(filter).Select(product => new ProductWithMainImageDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.ToString("N"),
                    BrandName = product.Brand.Name,
                    Slug = product.Slug,
                    MainImage = product.MainImage,
                    RatingAverage = product.Reviews.Select(review => (int?)(review.RatingValue)).Cast<decimal>().Average()
                }).AsQueryable();
            }
        }
         private async Task<IEnumerable<ProductWithMainImageDTO>> GetLast10ProductsList()
        {
             var productList= await  _productRepository.GetAllAsync();  
           return productList.Select(product => new ProductWithMainImageDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.ToString("N"),
                BrandName = product.Brand.Name,
                Slug = product.Slug,
                MainImage = product.MainImage,
                RatingAverage = product.Reviews.Select(review => (int?)(review.RatingValue)).Cast<decimal>().Average()
            }).OrderByDescending(x => x.Id).Take(10).ToList();
        }
    }
}
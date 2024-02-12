using Business.Abstarct;
using Business.DTOs;
using Core.ActionFilters;
using Core.Ultilities.Responses.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IResponse> GetCategories()
        {
            return await _categoryService.GetAllAsync();
        }

        [HttpGet("options")]
        public async Task<IResponse> GetCategoriesWithOptions()
        {
            return await _categoryService.GetCategoriesWithOptionsAsync();
        }


        [HttpGet("{id}")]
        public async Task<IResponse> GetCategory(Guid id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> AddCategory(CategoryDTO model)
        {
            return await _categoryService.AddAsync(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> UpdateCategory(CategoryDTO model)
        {
            return await _categoryService.UpdateAsync(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IResponse> RemoveCategory(Guid id)
        {
            return await _categoryService.RemoveAsync(id);
        }
    }
}

using Business.Abstarct;
using Business.DTOs;
using Business.Filters;
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
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IResponse> GetLast10ProductsWithImage()
        {
            return await _productService.GetLast10ProductsWithImage();
        }

        [HttpGet("getproducts")]
        public IResponse GetProducts([FromQuery] ProductFilter filter)
        {
            return _productService.GetProductsWithImage(filter);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> AddProduct([FromForm] ProductDTO model)
        {
            return await _productService.AddAsync(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> UpdateProduct([FromForm] ProductDTO model)
        {
            return await _productService.UpdateAsync(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}/adminproduct")]
        public async Task<IResponse> GetAdminProduct(Guid id)
        {
            return await _productService.GetAdminProduct(id);
        }

        [HttpGet("{slug}")]
        public async Task<IResponse> GetProductDetail(string slug)
        {
            return await _productService.GetProductDetail(slug);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IResponse> RemoveProduct(Guid id)
        {
            return await _productService.RemoveAsync(id);
        }
    }
}

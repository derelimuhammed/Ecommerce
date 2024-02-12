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
    public class BasketsController : ControllerBase
    {
        private IBasketService _basketService;
        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IResponse> GetBasketWithTotalPrice()
        {
            return await _basketService.GetBasketWithTotalPriceAsync();
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> AddToBasket(AddUpdateBasketDTO model)
        {
            return await _basketService.AddToBasketAsync(model);
        }

        [Authorize]
        [HttpPut]
        [ServiceFilter(typeof(NullFilterAttribute))]
        public async Task<IResponse> UpdateBasket(AddUpdateBasketDTO model)
        {
            return await _basketService.UpdateAsync(model);
        }

        [Authorize]
        [HttpDelete("{productid}")]
        public async Task<IResponse> RemoveFromBasket(Guid productid)
        {
            return await _basketService.RemoveFromBasket(productid);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IResponse> ClearBasket()
        {
            return await _basketService.ClearBasket();
        }
    }
}

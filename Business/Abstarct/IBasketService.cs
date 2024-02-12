using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using Core.Ultilities.Responses.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
     public interface IBasketService
    {
        Task<IResponse> AddToBasketAsync(AddUpdateBasketDTO model);
        Task<IResponse> RemoveFromBasket(Guid productid);
        Task<IResponse> ClearBasket();
        Task CreateBasketForUserAsync(Guid userid);
        Task<DataResponse<BasketDetail>> GetBasketWithTotalPriceAsync();
        Task<Basket> GetBasketByUserId(Guid userid);
        Task<IEnumerable<Basket>> GetAllAsync();
        Task<Basket> GetByIdAsync(Guid id);
        Task<IResponse> UpdateAsync(AddUpdateBasketDTO model);
        Task RemoveAsync(Guid id);
    }
}

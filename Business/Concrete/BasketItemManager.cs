using Business.Abstarct;
using Business.Constants;
using Core.Exceptions;
using Core.Ultilities.Responses.Abstract;
using Core.Ultilities.Responses.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
     public class BasketItemManager : IBasketItemService
    {
        private IBasketItemRepository _basketItemRepository;
        public BasketItemManager(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        public async Task<IResponse> ClearBasket(Guid basketId)
        {
            var basketitems = await _basketItemRepository.GetAllAsync(x => x.BasketId == basketId);
            if (basketitems.Count() > 0)
            {
                await _basketItemRepository.RemoveRangeAsync(basketitems);
                return new SuccessResponse(200, Messages.DeletedSuccessfully);
            }
            else
            {
                throw new ApiException(404, Messages.NotFound);
            }
        }

        public async Task<IResponse> RemoveFromBasket(Guid basketId, Guid productId)
        {
            var basketitem = await _basketItemRepository.GetAsync(x => x.BasketId == basketId && x.ProductId == productId);
            if (basketitem != null)
            {
                await _basketItemRepository.RemoveAsync(basketitem);
                return new SuccessResponse(200, Messages.DeletedSuccessfully);
            }
            else
            {
                throw new ApiException(404, Messages.NotFound);
            }
        }
    }
}

using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IBasketItemService
    {
        Task<IResponse> RemoveFromBasket(Guid basketId,Guid productId);
        Task<IResponse> ClearBasket(Guid basketId);
    }
}

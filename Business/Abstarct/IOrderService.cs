using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IOrderService
    {
        Task<IResponse> AddAsync(OrderDTO model);
        Task<IResponse> GetUserOrdersAsync();
        Task<IResponse> GetOrderDetailByOrderNumber(string ordernumber);
        Task<IResponse> GetAdminOrderDetailAsync(string ordernumber);
        Task<IResponse> GetAdminOrdersAsync();
        Task<IResponse> UpdateAsync(AdminOrderDetailDTO model);

    }
}

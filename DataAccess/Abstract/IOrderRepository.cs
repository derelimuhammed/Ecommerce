using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
     public interface IOrderRepository : IEntityRepository<Order>
    {
        //Task<IEnumerable<UserOrderDTO>> GetOrdersByUserIdAsync(string userid);
        //Task<OrderDetail> GetOrderDetailByOrderNumberAsync(string ordernumber);
        //Task<IEnumerable<UserOrderDTO>> GetAdminOrdersAsync();
        //Task<AdminOrderDetailDTO> GetAdminOrderDetailAsync(string ordernumber);
    }
}


using System;
using System.Linq;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Threading.Tasks;
using Business.Abstarct;
using Core.Ultilities.Responses.Concrete;
using Core.Ultilities.Responses.Abstract;

namespace Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        private IOrderStatusRepository _orderStatusRepository;
        public OrderStatusManager(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<IResponse> GetAllAsync()
        {
            var orderstatuses = await _orderStatusRepository.GetAllAsync();
            return new DataResponse<IEnumerable<OrderStatus>>(orderstatuses, 200);
        }
    }

}
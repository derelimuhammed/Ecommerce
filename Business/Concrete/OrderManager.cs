using AutoMapper;
using Business.Abstarct;
using Business.Constants;
using Business.DTOs;
using Business.ValidationRules.FluentValidation.OrderValidators;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Core.Ultilities.Responses.Abstract;
using Core.Ultilities.Responses.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
      public class OrderManager : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IBasketService _basketService;
        private IHttpContextAccessor _httpContextAccessor;
        private IMapper _mapper;
        public OrderManager(IOrderRepository orderRepository, IBasketService basketService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _basketService = basketService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddOrderValidator))]
        public async Task<IResponse> AddAsync(OrderDTO model)
        {
            string userid = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            string cardname = "John Doe";
            var cardnumber = "5528790000000008";
            var expirationMonth = "12";
            var expirationYear = "2030";
            var cvc = "123";
            if (model.CardName== cardname && model.CardNumber==cardnumber&& model.ExpirationMonth==expirationMonth && model.ExpirationYear==expirationYear  && model.Cvc == cvc)
            {
                var basket = await _basketService.GetBasketWithTotalPriceAsync();
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderStatusId = Guid.NewGuid(),
                    UserId =Guid.Parse(userid),
                    OrderNumber = new Random().Next(111111, 999999).ToString(),
                    TotalPrice = Convert.ToDecimal(basket.Data.TotalPrice),
                    OrderItems = basket.Data.BasketItems.Select(basketitem => new OrderItem()
                    {
                        ProductId = basketitem.ProductId,
                        Quantity = basketitem.Quantity,
                    }).ToList()
                };
                await _orderRepository.AddAsync(order);
                await _basketService.ClearBasket();
                return new SuccessResponse(200, Messages.YourOrderIsBeingProcessed);
            }
            throw new ApiException(400, Messages.PaymentFailed);
        }

        [ValidationAspect(typeof(UpdateOrderValidator))]
        public async Task<IResponse> UpdateAsync(AdminOrderDetailDTO model)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == model.Id);
            if (order != null)
            {
                order.Id = model.Id;
                order.OrderStatusId = model.OrderStatusId;
                await _orderRepository.UpdateAsync(order);
                return new SuccessResponse(200, Messages.UpdatedSuccessfully);
            }
            throw new ApiException(404, Messages.NotFound);
        }
           
        public async Task<IResponse> GetUserOrdersAsync()
        {
            string? userid = _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var orders = await _orderRepository.GetAllAsync(x=>x.UserId==Guid.Parse(userid));
            var userOrders=_mapper.Map<IEnumerable<UserOrderDTO>>(orders);
            return new DataResponse<IEnumerable<UserOrderDTO>>(userOrders, 200);
        }

        public async Task<IResponse> GetOrderDetailByOrderNumber(string ordernumber)
        {
            var order = await _orderRepository.GetAllAsync(x=>x.OrderNumber==ordernumber);
            var orderdetail=_mapper.Map<OrderDetailDTO>(order.FirstOrDefault());
            if (orderdetail!= null)
            {
                return new DataResponse<OrderDetailDTO>(orderdetail, 200);
            }
            throw new ApiException(404, Messages.NotFound);
        }

        public async Task<IResponse> GetAdminOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var adminorders=_mapper.Map<IEnumerable<UserOrderDTO>>(orders);
            return new DataResponse<IEnumerable<UserOrderDTO>>(adminorders, 200);
        }

        public async Task<IResponse> GetAdminOrderDetailAsync(string ordernumber)
        {
            var adminorder = await GetAdminOrderDetail(ordernumber);
            if (adminorder != null)
            {
                return new DataResponse<AdminOrderDetailDTO>(adminorder, 200);
            }
            throw new ApiException(404, Messages.NotFound);
        }
        private async Task<AdminOrderDetailDTO> GetAdminOrderDetail(string ordernumber)
        {
            var orders=await  _orderRepository.GetAllAsync();
           var getOrdersNum= orders.Where(o=>o.OrderNumber==ordernumber).FirstOrDefault();
          return  _mapper.Map<AdminOrderDetailDTO>(getOrdersNum);
        }
    }
}


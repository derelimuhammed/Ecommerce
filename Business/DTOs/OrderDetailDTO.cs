using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
     public class OrderDetailDTO :IDto
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string TotalPrice { get; set; }
        public UserDetailDTO User { get; set; }
        public AddressDetailDTO Address { get; set; }
        public string OrderStatus { get; set; }
        public IEnumerable<OrderItemDetailDTO> OrderItems { get; set; }
    }
}

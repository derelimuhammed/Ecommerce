using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AdminOrderDetailDTO : IDto
    {
        public Guid Id { get; set; }
        public Guid OrderStatusId { get; set; }
    }
}

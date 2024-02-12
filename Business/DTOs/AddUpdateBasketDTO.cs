using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AddUpdateBasketDTO : IDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
     public class BasketItemDetail : IDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string MainImage { get; set; }
        public int Quantity { get; set; }
    }
}

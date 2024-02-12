using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BasketDetail : IDto
    {
        public Guid Id { get; set; }
        public List<BasketItemDetail> BasketItems { get; set; }
        public string TotalPrice { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductOptionDetailDTO :IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OptionValueDetailDTO OptionValue { get; set; }
    }
}

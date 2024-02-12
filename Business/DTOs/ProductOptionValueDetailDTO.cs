using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductOptionValueDetailDTO:IDto
    {
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AdminProductOptionValueDetailDTO : IDto
    {
        public Guid OptionId { get; set; }
        public Guid OptionValueId { get; set; }
    }
}

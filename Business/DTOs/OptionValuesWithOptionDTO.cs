using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class OptionValuesWithOptionDTO : IDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid OptionId { get; set; }
        public OptionDTO Option { get; set; }
    }
}

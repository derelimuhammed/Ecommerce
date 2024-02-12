using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class OptionsAndValuesDTO : IDto
    {
        public IEnumerable<CategoryOptionDetailDTO> Options { get; set; }
    }
}

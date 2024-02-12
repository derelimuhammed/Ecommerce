using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class BrandDetailDTO : IDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}

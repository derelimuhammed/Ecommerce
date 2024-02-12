using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
     public class BrandDTO : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Image { get; set; }
    }
}

﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class AdminProductDetailDTO : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string MainImage { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public IEnumerable<ProductImageDTO> ProductImages { get; set; }
        public IEnumerable<AdminProductOptionValueDetailDTO> ProductOptionValues { get; set; }
    }
}

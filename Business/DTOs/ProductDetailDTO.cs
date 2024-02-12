using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ProductDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string MainImage { get; set; }
        public string Price { get; set; }
        public BrandDetailDTO Brand { get; set; }
        public IEnumerable<ProductImageDTO> ProductImages { get; set; }
        public IEnumerable<ProductOptionValueDetailDTO> ProductOptionValues { get; set; }
        public IEnumerable<ReviewDetailDTO> Reviews { get; set; }
    }
}

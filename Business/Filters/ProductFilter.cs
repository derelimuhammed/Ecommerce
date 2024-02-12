using AutoFilterer.Attributes;
using AutoFilterer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filters
{
     public class ProductFilter : OrderableFilterBase
    {
        public Range<decimal> Price { get; set; }
        public CategoryFilter Category { get; set; }
        public BrandFilter Brand { get; set; }
	[IgnoreFilter]
        public ProductOptionValueFilter ProductOptionValues { get; set; }
        [IgnoreFilter]
        public string Search { get; set; }
        [IgnoreFilter]
        public int Page { get; set; }
        [IgnoreFilter]
        public int PageSize { get; set; }
    }
}

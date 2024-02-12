using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filters
{
    public class CategoryFilter: FilterBase
    {
        [StringFilterOptions(StringFilterOption.Contains)]
        public string Slug { get; set; }
    }
}

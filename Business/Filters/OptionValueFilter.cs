using AutoFilterer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filters
{
    public class OptionValueFilter : FilterBase
    {
        public string[] Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class ProductOptions : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<OptionValue> OptionValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class OptionValue : BaseEntity
    {
        public string Value { get; set; }
        public Guid OptionId { get; set; }
        public virtual ProductOptions Option { get; set; }
    }
}

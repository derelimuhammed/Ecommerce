using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class CategoryOption : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}

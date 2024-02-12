using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CategoryOption> CategoryOptions { get; set; }
    }
}

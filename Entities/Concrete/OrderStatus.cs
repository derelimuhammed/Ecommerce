using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class OrderStatus : BaseEntity
    {
        public string OderStatus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Basket:BaseEntity
    {
        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
        }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}

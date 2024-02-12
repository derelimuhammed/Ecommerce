using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Review : BaseEntity
    {
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public byte RatingValue { get; set; }
    }
}

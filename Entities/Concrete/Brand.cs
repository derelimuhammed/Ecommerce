using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

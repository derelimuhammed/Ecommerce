using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSliderRepository : EfEntityRepositoryBase<Slider, ECommerceContext>, ISliderRepository
    {
        public EfSliderRepository(ECommerceContext context) : base(context)
        {}
    }
}

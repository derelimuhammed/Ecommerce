using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBasketRepository : EfEntityRepositoryBase<Basket, ECommerceContext>, IBasketRepository
    {
        public EfBasketRepository(ECommerceContext context) : base(context)
        {

        }

        public async Task<Basket> GetBasketByUserId(Guid userid)
        {
            return await _context.Baskets
                    .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.UserId ==userid);
        }
    }
}

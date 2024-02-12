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
    public class EfOptionRepository : EfEntityRepositoryBase<ProductOptions, ECommerceContext>, IOptionRepository
    {
        public EfOptionRepository(ECommerceContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ProductOptions>> GetOptionsWithValuesAsync()
        {
            return await _context.Options.Include(x => x.OptionValues).ToListAsync();
        }

       
    }
}

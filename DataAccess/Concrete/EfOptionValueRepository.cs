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
    public class EfOptionValueRepository : EfEntityRepositoryBase<OptionValue, ECommerceContext>, IOptionValueRepository
    {
        public EfOptionValueRepository(ECommerceContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OptionValue>> GetOptionValuesByOptionIdAsync(Guid optionid)
        {
            return await _context.OptionValues.Where(x => x.OptionId == optionid).ToListAsync();
        }

        public async Task<IEnumerable<OptionValue>> GetOptionValuesWithOption()
        {
            return await _context.OptionValues.Include(x => x.Option).ToListAsync();
        }
    }
}

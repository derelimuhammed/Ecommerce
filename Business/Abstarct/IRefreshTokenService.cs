using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetByCodeAsync(string code);
        Task<RefreshToken> GetByUserIdAsync(Guid userid);
        Task<RefreshToken> AddAsync(RefreshToken entity);
        Task<IEnumerable<RefreshToken>> GetAllAsync();
        Task<RefreshToken> GetByIdAsync(Guid id);
        Task UpdateAsync(RefreshToken entity);
        Task RemoveAsync(RefreshToken entity);
    }
}

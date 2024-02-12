using Business.Abstarct;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	   public class RefreshTokenManager : IRefreshTokenService
    {
        private IRefreshTokenRepository _refreshTokenRepository;
        public RefreshTokenManager(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> GetByIdAsync(Guid id)
        {
            return await _refreshTokenRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RefreshToken>> GetAllAsync()
        {
            return await _refreshTokenRepository.GetAllAsync();
        }

        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            return await _refreshTokenRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(RefreshToken entity)
        {
            await _refreshTokenRepository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(RefreshToken entity)
        {
            await _refreshTokenRepository.RemoveAsync(entity);
        }

        public async Task<RefreshToken> GetByCodeAsync(string code)
        {
            return await _refreshTokenRepository.GetAsync(x => x.Code == code);
        }

        public async Task<RefreshToken> GetByUserIdAsync(Guid userid)
        {
            return await _refreshTokenRepository.GetAsync(x => x.UserId ==userid);
        }
    }
}

using Business.Abstarct;
using Business.DTOs;
using Core.Configurations;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly JWTOptions _jwtOptions;
        private readonly UserManager<User> _userManager;
        public TokenManager(IOptions<JWTOptions> options, UserManager<User> userManager)
        {
            _jwtOptions = options.Value;
            _userManager = userManager;
        }

        public async Task<TokenDTO> CreateToken(User user)
        {
            try
            {
                var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);
                var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenExpiration);
                var keyBytes = Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey);
                // SymmetricSecurityKey oluşturma
                var securityKey = new SymmetricSecurityKey(keyBytes);
                // SigningCredentials oluşturma
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience[0],
                    expires: accessTokenExpiration,
                     notBefore: DateTime.Now,
                     claims: await GetClaims(user, _jwtOptions.Audience),
                     signingCredentials: signingCredentials);

                var handler = new JwtSecurityTokenHandler();
                bool tokan = handler.CanWriteToken;
                var tokkan = handler.CanValidateToken;

                var token = handler.WriteToken(jwtSecurityToken);

                var tokenDto = new TokenDTO
                {
                    AccessToken = token,
                    RefreshToken = CreateRefreshToken(),
                    AccessTokenExpiration = accessTokenExpiration,
                    RefreshTokenExpiration = refreshTokenExpiration
                };

                return tokenDto;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private async Task<IEnumerable<Claim>> GetClaims(User user, List<String> audiences)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }

    }
}

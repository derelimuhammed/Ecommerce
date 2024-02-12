using Business.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface ITokenService
    {
        Task<TokenDTO> CreateToken(User user);
    }
}

using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IAddressService
    {
        Task<IResponse> AddAsync(AddressDTO model);
        Task<IResponse> GetAllAsync();
        Task<IResponse> GetUserAddresses();
        Task<IResponse> GetByIdAsync(Guid id);
        Task<IResponse> UpdateAsync(AddressDTO model);
        Task<IResponse> RemoveAsync(Guid id);
    }
}

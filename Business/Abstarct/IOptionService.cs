using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IOptionService
    {
        Task<IResponse> AddAsync(OptionDTO model);
        Task<IResponse> GetAllAsync();
        Task<IResponse> GetOptionsWithValuesAsync();
        Task<IResponse> GetByIdAsync(Guid id);
        Task<IResponse> UpdateAsync(OptionDTO model);
        Task<IResponse> RemoveAsync(Guid id);
    }
}

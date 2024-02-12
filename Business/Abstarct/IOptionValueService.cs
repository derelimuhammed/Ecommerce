using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
     public interface IOptionValueService
    {
        Task<IResponse> AddAsync(OptionValueDTO model);
        Task<IResponse> GetAllAsync();
        Task<IResponse> GetOptionValuesWithOption();
        Task<IResponse> GetOptionValuesByProductOptionIdAsync(Guid optionid);
        Task<IResponse> GetByIdAsync(Guid id);
        Task<IResponse> UpdateAsync(OptionValueDTO model);
        Task<IResponse> RemoveAsync(Guid id);
    }
}

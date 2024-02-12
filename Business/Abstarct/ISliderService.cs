using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
     public interface ISliderService
    {
        Task<IResponse> AddAsync(SliderDTO model);
        Task<IResponse> GetAllAsync();
        Task<IResponse> GetByIdAsync(Guid id);
        Task<IResponse> UpdateAsync(SliderDTO model);
        Task<IResponse> RemoveAsync(Guid id);
    }
}

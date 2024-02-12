using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
     public interface ICategoryService
    {
        Task<IResponse> GetAllAsync();
        Task<IResponse> GetByIdAsync(Guid id);
        Task<IResponse> RemoveAsync(Guid id);
        Task<IResponse> AddAsync(CategoryDTO model);
        Task<IResponse> UpdateAsync(CategoryDTO model);
		Task<IResponse> GetCategoriesWithOptionsAsync();
	}
}

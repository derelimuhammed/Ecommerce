using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IReviewService
    {
        Task<IResponse> AddAsync(ReviewDTO model);
        Task<IResponse> GetAdminReviews();
        Task<IResponse> RemoveAsync(Guid id);
    }
}

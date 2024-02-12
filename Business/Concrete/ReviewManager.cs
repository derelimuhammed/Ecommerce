
using System;
using System.Linq;
using System.Collections.Generic;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Business.Constants;
using System.Security.Claims;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Business.Abstarct;
using Business.DTOs;
using Core.Ultilities.Responses.Concrete;
using Core.Ultilities.Responses.Abstract;
using Microsoft.EntityFrameworkCore;
using Business.ValidationRules.FluentValidation.ReviewValidators;

namespace Business.Concrete
{
    public class ReviewManager : IReviewService
	{
		private IReviewRepository _reviewRepository;
		private IHttpContextAccessor _httpContextAccessor;
		private IMapper _mapper;
		public ReviewManager(IReviewRepository reviewRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
		}

		[ValidationAspect(typeof(AddReviewValidator))]
		public async Task<IResponse> AddAsync(ReviewDTO model)
		{
			var review = _mapper.Map<Review>(model);
			review.ReviewDate = DateTime.Now;
			Guid result = Guid.Empty;
			review.UserId = Guid.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
			await _reviewRepository.AddAsync(review);
			return new SuccessResponse(200, Messages.AddedSuccesfully);
		}

		public async Task<IResponse> RemoveAsync(Guid id)
		{
			var review = await _reviewRepository.GetByIdAsync(id);
			if (review == null)
			{
				throw new ApiException(404, Messages.NotFound);
			}
			await _reviewRepository.RemoveAsync(review);
			return new SuccessResponse(200, Messages.DeletedSuccessfully);
		}

		public async Task<IResponse> GetAdminReviews()
		{
			var adminreviews = await GetAdminMapReviews();
			return new DataResponse<IEnumerable<ReviewDetailDTO>>(adminreviews, 200);
		}
		public async Task<IEnumerable<ReviewDetailDTO>> GetAdminMapReviews()
		{

			var reviews = await _reviewRepository.GetAllAsync();

			return reviews.Select(review => new ReviewDetailDTO()
			{
				Id = review.Id,
				Description = review.Description,
				ReviewDate = review.ReviewDate,
				RatingValue = review.RatingValue,
				User = new UserDetailDTO()
				{
					Id = review.User.Id,
					FirstName = review.User.FirstName,
					LastName = review.User.LastName
				}
			}).ToList();
		}
	}
}
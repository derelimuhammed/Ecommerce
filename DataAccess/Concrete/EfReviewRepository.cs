using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
	public class EfReviewRepository : EfEntityRepositoryBase<Review, ECommerceContext>, IReviewRepository
	{
		public EfReviewRepository(ECommerceContext context) : base(context)
		{

		}

		
	}
}

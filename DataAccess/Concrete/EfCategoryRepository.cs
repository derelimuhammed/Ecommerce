
using System;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Core.Ultilities.Helpers;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category, ECommerceContext>, ICategoryRepository
    {
        private IMapper _mapper;
        public EfCategoryRepository(ECommerceContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        
    }
}

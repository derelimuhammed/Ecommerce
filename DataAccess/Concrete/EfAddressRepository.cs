﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
   public class EfAddressRepository : EfEntityRepositoryBase<Address, ECommerceContext>, IAddressRepository
    {
        public EfAddressRepository(ECommerceContext context) : base(context)
        {

        }
    }
}

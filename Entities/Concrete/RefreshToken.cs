﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concrete
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}

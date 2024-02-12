﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class LoginDTO : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

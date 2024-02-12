﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Slider : BaseEntity
    {
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}

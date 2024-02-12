﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CategoryOptionDetailDTO : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OptionValueDetailDTO> OptionValues { get; set; }
    }
}

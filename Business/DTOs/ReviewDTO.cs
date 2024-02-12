﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class ReviewDTO : IDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public byte RatingValue { get; set; }
    }
}
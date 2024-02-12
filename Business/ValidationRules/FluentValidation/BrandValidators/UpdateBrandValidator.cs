using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BrandValidators
{
    public class UpdateBrandValidator : AbstractValidator<BrandDTO>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

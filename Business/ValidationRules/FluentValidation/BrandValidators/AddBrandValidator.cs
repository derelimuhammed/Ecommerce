using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BrandValidators
{
    public class AddBrandValidator : AbstractValidator<BrandDTO>
    {
        public AddBrandValidator()
        {
            RuleFor(x => x.ImageFile).NotNull();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductOptionValueValidator
{
    public class AddProductOptionValueValidator:AbstractValidator<ProductOptionValueDTO>
    {
        public AddProductOptionValueValidator()
        {
            RuleFor(x => x.OptionId).NotEmpty();
            RuleFor(x => x.OptionValueId).NotEmpty();
        }
    }
}

using Business.DTOs;
using Business.ValidationRules.FluentValidation.ProductOptionValueValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.ProductValidators
{
     public class AddProductValidator:AbstractValidator<ProductDTO>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Image).NotNull();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleForEach(x => x.OptionValues).SetValidator(new AddProductOptionValueValidator());
        }
    }
}

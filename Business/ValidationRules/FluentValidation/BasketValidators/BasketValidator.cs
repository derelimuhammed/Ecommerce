using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.BasketValidators
{
    public class BasketValidator:AbstractValidator<AddUpdateBasketDTO>
    {
        public BasketValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
        }
    }
}

using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.OrderValidators
{
     public class AddOrderValidator:AbstractValidator<OrderDTO>
    {
        public AddOrderValidator()
        {
            RuleFor(x => x.Cvc).NotEmpty();
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.ExpirationMonth).NotEmpty();
            RuleFor(x => x.ExpirationYear).NotEmpty();
            RuleFor(x => x.AddressId).NotEmpty();
        }
    }
}

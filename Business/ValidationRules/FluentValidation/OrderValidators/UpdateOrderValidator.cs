using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.OrderValidators
{
    public class UpdateOrderValidator : AbstractValidator<AdminOrderDetailDTO>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OrderStatusId).NotEmpty();
            
        }
    }
}

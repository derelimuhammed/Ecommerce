using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.OptionValueValidators
{
    public class UpdateOptionValueValidator : AbstractValidator<OptionValueDTO>
    {
        public UpdateOptionValueValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.OptionId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}

using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.OptionValidators
{
   public class AddOptionValidator : AbstractValidator<OptionDTO>
    {
        public AddOptionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

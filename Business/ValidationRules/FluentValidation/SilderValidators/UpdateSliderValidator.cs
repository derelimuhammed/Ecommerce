using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.SilderValidators
{
	public class UpdateSliderValidator : AbstractValidator<SliderDTO>
    {
        public UpdateSliderValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Active).NotNull();
        }
    }
}

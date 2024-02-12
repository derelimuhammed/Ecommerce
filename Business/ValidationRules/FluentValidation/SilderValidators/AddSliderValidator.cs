using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.SilderValidators
{
	public class AddSliderValidator : AbstractValidator<SliderDTO>
	{
		public AddSliderValidator()
		{
			RuleFor(x => x.ImageFile).NotNull();
			RuleFor(x => x.Active).NotNull();
		}
	}
}

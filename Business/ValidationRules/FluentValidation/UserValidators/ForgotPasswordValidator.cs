using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
	public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDTO>
	{
		public ForgotPasswordValidator()
		{
			RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
		}
	}
}

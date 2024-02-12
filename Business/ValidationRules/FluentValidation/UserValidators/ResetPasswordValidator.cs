using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.UserValidators
{
	public class ResetPasswordValidator : AbstractValidator<ResetPasswordDTO>
	{
		public ResetPasswordValidator()
		{
			RuleFor(x => x.Token).NotNull().NotEmpty();
			RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
			RuleFor(x => x.NewPassword).NotNull().NotEmpty();
			RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty();
			RuleFor(x => x).Custom((x, context) =>
			{
				if (x.NewPassword != x.ConfirmPassword)
				{
					context.AddFailure(nameof(x.NewPassword), "Passwords should match");
				}
			});
		}
	}
}

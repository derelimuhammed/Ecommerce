using Business.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.RoleValidators
{
	public class AddRoleValidator:AbstractValidator<RoleDTO>
    {
        public AddRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

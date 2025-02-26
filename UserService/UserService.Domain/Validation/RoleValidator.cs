using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserService.Domain.Validation
{
    public class RoleValidator : AbstractValidator<string>
    {
        public RoleValidator()
        {

            RuleFor(role => role)
             .NotNull().WithMessage("UserRole cannot be null.")
             .IsInEnum().WithMessage("UserRole must be a valid value.");
        }
    }
}

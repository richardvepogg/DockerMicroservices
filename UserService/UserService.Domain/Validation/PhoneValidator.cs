using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserService.Domain.Validation
{
    public class PhoneValidator : AbstractValidator<string>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone)
           .NotEmpty().WithMessage("Phone number is required.")
           .Matches(new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$")).WithMessage("Phone format is not valid. Use (XX) XXXXX-XXXX or (XX) XXXX-XXXX.");
        }
    }
}

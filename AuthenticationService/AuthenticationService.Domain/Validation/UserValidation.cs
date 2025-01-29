using AuthenticationService.Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;


namespace UserService.Domain.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(user => user.Id)
                .NotNull()
                .GreaterThan(0);

            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(user => user.Role)
             .NotNull().WithMessage("UserRole cannot be null.")
             .IsInEnum().WithMessage("UserRole must be a valid value.");

            RuleFor(user => user.Contact.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$")).WithMessage("Phone format is not valid. Use (XX) XXXXX-XXXX or (XX) XXXX-XXXX.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character.");
        }
    }
}

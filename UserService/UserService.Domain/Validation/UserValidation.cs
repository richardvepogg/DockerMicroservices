using FluentValidation;
using System.Text.RegularExpressions;
using UserService.Domain.Entities;

namespace UserService.Domain.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(user => user.id)
                .NotNull()
                .GreaterThan(0);

            RuleFor(user => user.name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(user => user.email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email is not valid.")
                .Matches(new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                .WithMessage("Email format is not valid.");

            RuleFor(user => user.phone)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$"))
                .WithMessage("Phone format is not valid. Use (XX) XXXXX-XXXX or (XX) XXXX-XXXX.");

            RuleFor(user => user.password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]")
                .WithMessage("Password must contain at least one number.")
                .Matches(@"[\W]")
                .WithMessage("Password must contain at least one special character.");

            RuleFor(user => user.role)
                .NotEmpty()
                .WithMessage("Role is required.");

            RuleFor(user => user.role)
             .NotNull().WithMessage("UserRole cannot be null.")
             .IsInEnum().WithMessage("UserRole must be a valid value.");
        }
    }
}

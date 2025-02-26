using FluentValidation;


namespace UserService.Domain.Validation
{
    public class NameValidator : AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(name => name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}

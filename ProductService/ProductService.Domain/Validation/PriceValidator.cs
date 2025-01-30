using FluentValidation;
using ProductService.Domain.ValueObjects;

namespace ProductService.Domain.Validation
{
    public class PriceValidator : AbstractValidator<Price>
    {
        public PriceValidator()
        {
            RuleFor(price => price.Value)
                .GreaterThan(0).WithMessage("The price value must be greater than 0.");

            RuleFor(price => price.Currency)
                .IsInEnum().WithMessage("The currency must be a valid value.");
        }
    }
}

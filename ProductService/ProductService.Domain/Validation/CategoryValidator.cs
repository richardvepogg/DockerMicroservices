using FluentValidation;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Id)
                .GreaterThan(0).WithMessage("The category ID must be greater than 0.");

            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("The category name is required.");
        }
    }
}

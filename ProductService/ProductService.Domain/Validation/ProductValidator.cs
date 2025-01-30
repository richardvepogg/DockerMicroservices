using FluentValidation;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("The product name is required.");

            RuleFor(product => product.ProductPrice)
                .NotNull().WithMessage("The product price is required.")
                .SetValidator(new PriceValidator());

            RuleFor(product => product.CategoryId)
                .GreaterThan(0).WithMessage("The category ID must be greater than 0.");

            RuleFor(product => product.CategoryName)
                .NotEmpty().WithMessage("The category name is required.");

            RuleFor(product => product.Category)
                .NotNull().WithMessage("The category is required.")
                .SetValidator(new CategoryValidator());
        }
    }


}

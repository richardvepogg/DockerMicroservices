using Bogus;
using ProductService.Application.Products.Command.CreateProduct;

public static class CreateProductHandlerTestData
{
    public static Faker<CreateProductCommand> GerarComandoValido()
    {
        return new Faker<CreateProductCommand>()
            .RuleFor(c => c.name, f => f.Commerce.ProductName())
            .RuleFor(c => c.price, f => f.Finance.Amount(1, 1000))
            .RuleFor(c => c.priceMercadoLivre, f => f.Random.Bool() ? f.Finance.Amount(1, 1000) : (decimal?)null);
    }
}


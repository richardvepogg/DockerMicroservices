using ProductService.Domain.Common;
using ProductService.Domain.Validation;
using ProductService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities
{
    
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Price ProductPrice { get; set; }

        public Price? PriceMercadoLivre { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public Category Category { get; set; }

        public Product()
        { }

        public Product(string name, Price productPrice, Category category)
        {
            Name = name;
            ProductPrice = productPrice;
            CategoryId = category.Id;
            CategoryName = category.Name;
            Category = category;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void UpdatePrice(Price price)
        {
            ProductPrice = price;
        }

        public void UpdatePriceMercadoLivre(Price price)
        {
            PriceMercadoLivre = price;
        }
    }

}

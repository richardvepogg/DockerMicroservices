using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductService.Contracts.Enums;
using ProductService.Contracts.Models.Messages;
using ProductService.Contracts.ValueObjects;
using ProductService.Data.Context;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;


namespace ProductService.Application.Services
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductDbContext _contexto;
        private readonly IMapper _mapper;

        public ProductRepository(ProductDbContext ctx, IMapper mapper)
        {
            _contexto = ctx;
            _mapper = mapper;
        }

        public int Add(Product ProductVO)
        {

            Product Product = _mapper.Map<Product>(ProductVO);
            _contexto.Products.Add(Product);
            _contexto.SaveChanges();

            return Product.id;        
        }

        public Product Find(long id)
        {
            Product Product = _contexto.Products.FirstOrDefault(u => u.id == id)!;

            if (Product == null)
                return null;

            return _mapper.Map<ProductVO>(Product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _contexto.Products.ToList();
        }

        public void Remove(long id)
        {
            Product Product = _contexto.Products.FirstOrDefault(u => u.id == id);

            if (Product == null)
                return;

            _contexto.Products.Remove(Product);
            _contexto.SaveChanges();
        }

        public void Update(Product product)
        {
            _contexto.Update(product);

            return;
        }

        //public void UpdateProductRPA(ProductMessageUpdate ProductMessageUpdate)
        //{
        //    Product Product = _contexto.Products.FirstOrDefault(u => u.id == ProductMessageUpdate.id);

        //    if (Product == null)
        //        return;

        //    switch (ProductMessageUpdate.RPAMarketPlace)
        //    {
        //        case ERPAMarketPlace.MercadoLivre:
        //            Product.priceMercadoLivre = ProductMessageUpdate.price;
        //            _contexto.Entry(Product).Property(p => p.priceMercadoLivre).IsModified = true;
        //            break;
        //        case ERPAMarketPlace.Amazon:
        //            Product.priceValorAmazon = ProductMessageUpdate.price;
        //            _contexto.Entry(Product).Property(p => p.priceValorAmazon).IsModified = true;
        //            break;
        //    }

        //    _contexto.SaveChanges();
        //}

    }
}

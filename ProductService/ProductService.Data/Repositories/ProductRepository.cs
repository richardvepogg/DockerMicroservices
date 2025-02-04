using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;


namespace ProductService.Application.Services
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductDbContext _contexto;


        public ProductRepository(ProductDbContext ctx)
        {
            _contexto = ctx;
        }

        public async Task<Product> AddAsync(Product Product,CancellationToken cancellationToken = default)
        {
            await _contexto.Products.AddAsync(Product, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return Product;        
        }

        public async Task<Product?> FindAsyncById(long id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Products.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return  await _contexto.Products.ToListAsync(cancellationToken);
        }

        public async Task<bool> RemoveAsync(long id, CancellationToken cancellationToken = default)
        {
            Product? Product = await FindAsyncById(id, cancellationToken);
            if (Product == null)
                return false;

            _contexto.Products.Remove(Product);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _contexto.Update(product);
            await _contexto.SaveChangesAsync(cancellationToken);

            return product;
        }

    }
}

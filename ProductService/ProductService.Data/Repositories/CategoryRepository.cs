using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ProductDbContext _contexto;


        public CategoryRepository(ProductDbContext ctx)
        {
            _contexto = ctx;
        }

        public async Task<Category?> FindAsyncById(long id, CancellationToken cancellationToken)
        {
            return await _contexto.Categories.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
    }
}

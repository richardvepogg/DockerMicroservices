using ProductService.Contracts.Models.Messages;

namespace ProductService.Contracts.Interfaces
{
    public interface IProductUpdateHandler
    {
        Task HandleAsync(ProductMessageUpdate messageUpdate);
    }

}

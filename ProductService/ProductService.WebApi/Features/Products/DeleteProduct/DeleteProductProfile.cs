using AutoMapper;
using ProductService.Application.Products.Command.DeleteProduct;

namespace ProductService.WebApi.Features.Products.DeleteProduct
{
    public class DeleteProductProfile : Profile
    {
        public DeleteProductProfile()
        {
            CreateMap<int, DeleteProductCommand>()
                .ConstructUsing(id => new DeleteProductCommand(id));
        }
    }
}

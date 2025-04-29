using AutoMapper;
using MediatR;
using ProductService.Contracts.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Contracts.Models.Messages;

namespace ProductService.Application.Products.Command.UpdateProductPriceMessage
{
    public class ProductUpdateHandler : IProductUpdateHandler
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductUpdateHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task HandleAsync(ProductMessageUpdate messageUpdate)
        {
            var productCommand = _mapper.Map<UpdateProductMessagePriceCommand>(messageUpdate);
            await _mediator.Send(productCommand);
        }
    }

}

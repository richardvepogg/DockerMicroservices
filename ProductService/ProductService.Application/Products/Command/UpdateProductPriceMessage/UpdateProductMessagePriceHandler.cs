using AutoMapper;
using MediatR;
using ProductService.Contracts.Enums;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;


namespace ProductService.Application.Products.Command.UpdateProductPriceMessage
{
    public class UpdateProductMessagePriceHandler : IRequestHandler<UpdateProductMessagePriceCommand, UpdateProductMessagePriceResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductMessagePriceHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<UpdateProductMessagePriceResult> Handle(UpdateProductMessagePriceCommand command, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.FindAsyncById(command.Id);

            if (product == null || command.Price == null)
                return new UpdateProductMessagePriceResult(false);

            switch (command.RPAMarketPlace)
            {
                case ERPAMarketPlace.MercadoLivre:
                    product.UpdatePriceMercadoLivre(command.Price);
                    break;
            }

            Product updateProduct = await _productRepository.UpdateAsync(product);
            return new UpdateProductMessagePriceResult(true); 
        }


    }
}

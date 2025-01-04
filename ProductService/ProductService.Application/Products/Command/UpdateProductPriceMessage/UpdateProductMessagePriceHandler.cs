using AutoMapper;
using MediatR;
using ProductService.Application.Products.Command.UpdateProduct;
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
            Product product = _mapper.Map<Product>(command);

            Product updateProduct = await _productRepository.UpdateAsync(product);
            UpdateProductMessagePriceResult result = _mapper.Map<UpdateProductMessagePriceResult>(updateProduct);
            return result;
        }

        public async Task Handle(UpdateProductMessagePriceCommand command)
        {
            Product? product = await _productRepository.FindAsyncById(command.Id);

            if (product == null)
                return;

            switch (command.RPAMarketPlace)
            {
                case ERPAMarketPlace.MercadoLivre:
                    product.priceMercadoLivre = command.Price;
                    break;
                case ERPAMarketPlace.Amazon:
                    product.priceValorAmazon = command.Price;
                    product.priceValorAmazon = command.Price;
                    break;
            }

            await _productRepository.UpdateAsync(product);
        }


    }
}

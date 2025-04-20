using AutoMapper;
using ProductService.Contracts.Interfaces;
using ProductService.Contracts.Models.Messages;
using ProductService.Domain.Events; 

namespace ProductService.Application.Events
{
    public class ProductInsertedEventHandler : IEventHandler<ProductInsertedEvent>
    {
        private readonly IRabbitMQMessageSender _messageService;
        private readonly IMapper _mapper;

        public ProductInsertedEventHandler(IRabbitMQMessageSender messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public void Handle(ProductInsertedEvent productInsertedEvent)
        {
            ProductMessage productMessage = _mapper.Map<ProductMessage>(productInsertedEvent.Product);
            _messageService.SendMessage(productMessage);
        }
    }
}

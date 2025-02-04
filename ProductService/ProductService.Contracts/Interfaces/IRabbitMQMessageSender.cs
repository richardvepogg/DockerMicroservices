
using ProductService.Contracts.Models.Messages;

namespace ProductService.Contracts.Interfaces
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}

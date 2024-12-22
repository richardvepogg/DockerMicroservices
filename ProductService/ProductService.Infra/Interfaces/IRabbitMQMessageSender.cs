
using ProductService.Contracts.Models.Messages;

namespace ProductService.Infra.Interfaces
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}

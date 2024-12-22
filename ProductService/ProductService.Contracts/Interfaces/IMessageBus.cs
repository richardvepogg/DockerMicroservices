
using ProductService.Contracts.Models.Messages;

namespace ProductService.Contracts.Interfaces
{
    internal interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string topicName);

    }
}

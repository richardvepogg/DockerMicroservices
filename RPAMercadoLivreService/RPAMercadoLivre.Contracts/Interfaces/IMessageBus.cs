using RPAMercadoLivre.Contracts.Models.Messages;

namespace RPAMercadoLivre.Contracts.Interfaces
{
    internal interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string topicName);

    }
}

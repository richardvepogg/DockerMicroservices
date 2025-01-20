

using RPAMercadoLivre.Contracts.Models.Messages;

namespace RPAMercadoLIvre.Infra.Services.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }

}

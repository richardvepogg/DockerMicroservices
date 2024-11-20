using CadastroProduto.MessageBus;

namespace CadastroProduto.Infraestrutura.Services.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}

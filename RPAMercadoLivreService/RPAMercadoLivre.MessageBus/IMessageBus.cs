namespace RPAMercadoLivre.MessageBus
{
    internal interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string topicName);

    }
}

namespace ProductService.MessageBus.Interfaces
{
    internal interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string topicName);

    }
}

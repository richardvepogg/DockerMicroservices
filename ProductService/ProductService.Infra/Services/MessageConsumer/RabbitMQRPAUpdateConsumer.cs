using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using ProductService.Contracts.Models.Messages;
using ProductService.Contracts.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Infra.Services.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IProductUpdateHandler _productUpdateHandler;


        public RabbitMQCheckoutConsumer(IRabbitMQMessageSender rabbitMQMessageSender, IProductUpdateHandler productUpdateHandler)
        {
            _rabbitMQMessageSender = rabbitMQMessageSender;
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq",
                UserName = "adm",
                Password = "123"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "updateProdutoRPAqueue", false, false, false, arguments: null);
            _productUpdateHandler = productUpdateHandler;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                ProductMessageUpdate produtoMessageUpdate = JsonSerializer.Deserialize<ProductMessageUpdate>(content);
                AtualizarProduto(produtoMessageUpdate);
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("updateProdutoRPAqueue", false, consumer);
            return Task.CompletedTask;
        }

        private void AtualizarProduto(ProductMessageUpdate produtoMessageUpdate)
        {
            _productUpdateHandler.HandleAsync(produtoMessageUpdate);
        }
    }
}

using CadastroProduto.Infraestrutura.Services.RabbitMQSender;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Hosting;
using CadastroProduto.AcessoDados.AcessoBanco;
using System.Text.Json;
using CadastroProduto.Dominio.Messages;

namespace CadastroProduto.Infraestrutura.Services.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly IProdutoRepository _repositoryProduto;
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQCheckoutConsumer(IProdutoRepository repositoryProduto,
            IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _repositoryProduto = repositoryProduto;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            var factory = new ConnectionFactory
            {
                HostName = "172.18.0.9",
                UserName = "adm",
                Password = "123"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "updateProdutoRPAqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                ProdutoMessageUpdate produtoMessageUpdate = JsonSerializer.Deserialize<ProdutoMessageUpdate>(content);
                AtualizarProduto(produtoMessageUpdate);
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("updateProdutoRPAqueue", false, consumer);
            return Task.CompletedTask;
        }

        private void AtualizarProduto(ProdutoMessageUpdate produtoMessageUpdate)
        {
           
             _repositoryProduto.UpdateProdutoRPA(produtoMessageUpdate);
        }
    }
}

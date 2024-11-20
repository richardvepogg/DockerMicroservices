using CadastroProduto.Dominio.ValueObjects;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RPAMercadoLivre.Negocio.Services;
using SeuRPAMercadoLivreProjeto.Negocio.Servicos;
using System.Text;
using System.Text.Json;

namespace RPAMercadoLIvre.Infraestrutura.Services.MessageConsumer
{
    public class RabbitMQRPAConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IHttpService _httpService;
        private const string ExchangeName = "DirectRPAUpdateExchange";
        private const string PaymentOrderUpdateQueueName = "RPAUpdateQueueName";

        public RabbitMQRPAConsumer(HttpService httpService)
        {
            _httpService = httpService;

            var factory = new ConnectionFactory
            {
                HostName = "172.18.0.9",
                UserName = "adm",
                Password = "123"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(PaymentOrderUpdateQueueName, false, false, false, null);
            _channel.QueueBind(PaymentOrderUpdateQueueName, ExchangeName, "RPAProduto");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                ProdutoVO produtoVO = JsonSerializer.Deserialize<ProdutoVO>(content);
                BuscarProduto(produtoVO.nmProduto).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(PaymentOrderUpdateQueueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task BuscarProduto(string nmProduto)
        {
            string responseBody = await _httpService.GetHttpResponseBodyAsync($"https://lista.mercadolivre.com.br/{nmProduto}");
        }



    }

}

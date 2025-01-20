using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RPAMercadoLivre.Contracts.Models.Messages;
using RPAMercadoLivre.Domain.Interfaces;
using RPAMercadoLIvre.Infra.Services.RabbitMQSender;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RPAMercadoLIvre.Infra.Services.MessageConsumer
{
    public class RabbitMQRPAConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IHttpService _httpService;
        private IRabbitMQMessageSender _messageSender;
        private const string ExchangeName = "DirectProdutoUpdateExchange";
        private const string ProdutoMercadoLivreUpdateQueueName = "ProdutoMercadoLivreUpdateQueueName";
        private static readonly Regex precos = new Regex(
            pattern: @"R\$\s*\s*<\s*/\s*span\s*>\s*<\s*span\s*class\s*=\s*(?:""|')andes-money-amount__fraction\s*(?:""|')[^>]*>(?<valorAVista>[^<]*)<\s*/\s*span\s*>\s*<\s*/\s*span\s*>\s*<\s*span\s*class",
            options: RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            matchTimeout: TimeSpan.FromSeconds(15)
        );

        public RabbitMQRPAConsumer(IHttpService httpService, IRabbitMQMessageSender messageSender)
        {
            _httpService = httpService;
            _messageSender = messageSender;
            var factory = new ConnectionFactory
            {
                HostName = "172.18.0.9",
                UserName = "adm",
                Password = "123"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(ProdutoMercadoLivreUpdateQueueName, false, false, false, null);
            _channel.QueueBind(ProdutoMercadoLivreUpdateQueueName, ExchangeName, "RPAMercadoLivreProduto");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                ProductMessage produtoMessage = JsonSerializer.Deserialize<ProductMessage>(content);
                BuscarProduto(produtoMessage).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(ProdutoMercadoLivreUpdateQueueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task BuscarProduto(ProductMessage productMessage)
        {
            string responseBody = await _httpService.GetHttpResponseBodyAsync($"https://lista.mercadolivre.com.br/{productMessage.name}");

            MatchCollection matchCollection = precos.Matches(responseBody);

            Decimal valorFinal = new Decimal(0);

            foreach (Match match in matchCollection)
            {
                Decimal valor = new Decimal();

                if (Decimal.TryParse(match.Groups["valorAVista"].Value, out valor))
                {
                    if (valorFinal == 0)
                        valorFinal = valor;

                    valorFinal = valor < valorFinal ? valor : valorFinal;
                }
            }

            ProductMessageUpdate productMessageUpdate = new ProductMessageUpdate()
            {
                id = productMessage.id,
                value = valorFinal,
            };


            _messageSender.SendMessage(productMessageUpdate, "updateProdutoRPAqueue");
        }



    }

}

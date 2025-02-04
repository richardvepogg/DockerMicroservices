using ProductService.Contracts.Interfaces;
using ProductService.Contracts.Models.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;


namespace ProductService.Infra.Services.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private const string ExchangeName = "DirectProdutoUpdateExchange";
        private const string ProdutoMercadoLivreUpdateQueueName = "ProdutoMercadoLivreUpdateQueueName";
        private const string ProdutoAmazonUpdateQueueName = "ProdutoAmazonUpdateQueueName";

        public RabbitMQMessageSender()
        {
            _hostName = "172.18.0.9";
            _password = "123";
            _userName = "adm";
        }

        public void SendMessage(BaseMessage message)
        {
            if (ConnectionExists())
            {
                using IModel channel = _connection.CreateModel();
                channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, durable: false);
                channel.QueueDeclare(ProdutoMercadoLivreUpdateQueueName, false, false, false, null);
                channel.QueueDeclare(ProdutoAmazonUpdateQueueName, false, false, false, null);

                channel.QueueBind(ProdutoMercadoLivreUpdateQueueName, ExchangeName, "ProdutoMercadoLivre");
                channel.QueueBind(ProdutoAmazonUpdateQueueName, ExchangeName, "ProdutoAmazon");

                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(
                    exchange: ExchangeName, "ProdutoMercadoLivre", basicProperties: null, body: body);
                channel.BasicPublish(
                    exchange: ExchangeName, "ProdutoAmazon", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize((ProductMessage)message, options);
            byte[] body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private void CreateConnection()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch
            {
                throw;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null) return true;
            CreateConnection();
            return _connection != null;
        }
    }
}

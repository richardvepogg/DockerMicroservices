﻿using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using ProductService.Contracts.Models.Messages;
using MediatR;
using ProductService.Contracts.Interfaces;

namespace ProductService.Infra.Services.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;
        private IMediator _mediator;


        public RabbitMQCheckoutConsumer(IMediator mediator,
            IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _rabbitMQMessageSender = rabbitMQMessageSender;
            _mediator = mediator;
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
                ProductMessageUpdate produtoMessageUpdate = JsonSerializer.Deserialize<ProductMessageUpdate>(content);
                AtualizarProduto(produtoMessageUpdate);
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("updateProdutoRPAqueue", false, consumer);
            return Task.CompletedTask;
        }

        private void AtualizarProduto(ProductMessageUpdate produtoMessageUpdate)
        {
               _mediator.Send(produtoMessageUpdate);
        }
    }
}

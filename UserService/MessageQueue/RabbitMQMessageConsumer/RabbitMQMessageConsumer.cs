using BLL.DTO;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessageBus.RabbitMQMessageConsumer
{
    public class RabbitMQMessageConsumer : BackgroundService
    {
        //private readonly 
        private IConnection _connection;
        private IModel _channel;
        public RabbitMQMessageConsumer()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Password = "guest",
                UserName = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "User_Queue", false, false);

            _connection = _connection;
            _channel = _channel;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var costumer = new EventingBasicConsumer(_channel);
            costumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                User? user = JsonSerializer.Deserialize<User>(content);
                ProcessOrder(user).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("User_Queue", false, costumer);
            return Task.CompletedTask;
        }

        private async Task ProcessOrder(User user)
        {
            //acionar servico de envio
            throw new NotImplementedException();
        }
    }
}

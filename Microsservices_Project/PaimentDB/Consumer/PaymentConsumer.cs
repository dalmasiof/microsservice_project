using Entities.Entities;
using MessageBus;
using PaymentDB.Data.Context;
using PaymentDB.Data.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PaymentDB.Consumer
{
    public class PaymentConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;
        //private IRabbitMQMessageSender _rabbitMQMessageSender;


        public PaymentConsumer(IServiceScopeFactory scopeFactory)
        {   
            _scopeFactory = scopeFactory;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: MESSAGE_QUEUE_NAMES.PAYMENT_RECEIVE, false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentData model = JsonSerializer.Deserialize<PaymentData>(content);
                ProcessPayment(model).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(MESSAGE_QUEUE_NAMES.PAYMENT_RECEIVE, false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentData model)
        {
            using var scope = _scopeFactory.CreateScope();

            // Get a Dbcontext from the scope
            var context = scope.ServiceProvider
                .GetRequiredService<PaymentCOntext>();

            // Run a query on your context
            await context.paymentDatas.AddAsync(model);
            await context.SaveChangesAsync();
        }
    }
}

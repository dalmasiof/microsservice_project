using Entities.Entities;
using MessageBus;
using PaymentOrderDB.Data.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PaymentOrderDB.Consumer
{
    public class PaymentOrderConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;
        public PaymentOrderConsumer(IServiceScopeFactory scopeFactory)
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
            _channel.QueueDeclare(queue: MESSAGE_QUEUE_NAMES.UPDATE_PO, false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentData model = JsonSerializer.Deserialize<PaymentData>(content);
                UpdatePO(model).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(MESSAGE_QUEUE_NAMES.UPDATE_PO, false, consumer);
            return Task.CompletedTask;
        }

        private async Task UpdatePO(PaymentData model)
        {
            using var scope = _scopeFactory.CreateScope();

            // Get a Dbcontext from the scope
            var context = scope.ServiceProvider
                .GetRequiredService<PaymentOrderContext>();

            var po = context.PaymentOrders.Where(x => x.id == model.idPaymentOrder).FirstOrDefault();
            po.totalPayed += model.value;
            // Run a query on your context
            context.PaymentOrders.Update(po);
            await context.SaveChangesAsync();

        }
    }
}

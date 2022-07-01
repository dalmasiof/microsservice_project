using MessageBus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace AuthService
{

    public class ConsumerMessage : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        //private IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly string _queueName;


        public ConsumerMessage()
        {
            _queueName = MESSAGE_QUEUE_NAMES.USER_CREATE;
            //_userRepo = userRepository;
            //_rabbitMQMessageSender = rabbitMQMessageSender;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                UserData modelToCreate = JsonSerializer.Deserialize<UserData>(content);
                CreateUser(modelToCreate).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(_queueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task CreateUser(UserData model)
        {

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
    }
}

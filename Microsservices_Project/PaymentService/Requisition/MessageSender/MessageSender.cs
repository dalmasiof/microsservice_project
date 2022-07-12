using Entities.Entities;
using MessageBus;
using MessageBus.Const;
using PaymentService.ViewModel;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PaymentService.Requisition.MessageSender
{
    public class MessageSender : IMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private const string ExchangeName = MESSAGE_EXCHANGE_NAMES.PAYMENT;
        private const string PaymentQueue = MESSAGE_QUEUE_NAMES.PAYMENT_RECEIVE;
        private const string UpdatePOQueue = MESSAGE_QUEUE_NAMES.UPDATE_PO;

        public MessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(PaymentData message)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel();

                channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, durable: false);
                channel.QueueDeclare(PaymentQueue, false, false, false, null);
                channel.QueueDeclare(UpdatePOQueue, false, false, false, null);

                channel.QueueBind(PaymentQueue, ExchangeName, "Payment");
                channel.QueueBind(UpdatePOQueue, ExchangeName, "PaymentOrder");

                byte[] body = GetMessageAsByteArray(message);

                channel.BasicPublish(
                     exchange: ExchangeName, "Payment", basicProperties: null, body: body);
                channel.BasicPublish(
                    exchange: ExchangeName, "PaymentOrder", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(PaymentData message)
        {
          
            var json = JsonSerializer.Serialize<PaymentData>(message);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                //Log exception
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

using MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using UserService.MessageSender.Interfaces;
using UserService.Model;

namespace UserService.MessageSender
{
    public class MessageSender: IMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;

        public MessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage message, string queueName)
        {
            //if (ConnectionExists())
            //{
            //    using var channel = _connection.CreateModel();
            //    channel.ExchangeDeclare(queueName,ExchangeType.Fanout,durable:false);
            //    byte[] body = GetMessageAsByteArray(message);
            //    channel.BasicPublish(
            //        exchange: queueName, "", basicProperties: null, body: body);
            //}
        }

        //private byte[] GetMessageAsByteArray(BaseMessage message)
        //{
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //    };
        //    var json = JsonSerializer.Serialize<UserDTO>((UserDTO)message, options);
        //    var body = Encoding.UTF8.GetBytes(json);
        //    return body;
        //}

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

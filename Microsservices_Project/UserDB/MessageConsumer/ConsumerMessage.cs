﻿using MessageBus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using UserDB.Data.Repository;

namespace UserDB.MessageConsumer
{
    public class ConsumerMessage : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        //private IRabbitMQMessageSender _rabbitMQMessageSender;
        private  UserRepository _userRepo;
        private readonly string _queueName;
        private readonly string _exchangeName;


        public ConsumerMessage(UserRepository userRepository)
        {
            _exchangeName = MESSAGE_QUEUE_NAMES.USER_CREATE;
            _userRepo = userRepository;
            //_rabbitMQMessageSender = rabbitMQMessageSender;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(_exchangeName,ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(_queueName, _exchangeName,"");



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
                var result = _userRepo.Create(model);
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
    }
}

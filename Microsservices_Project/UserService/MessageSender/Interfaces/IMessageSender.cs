using MessageBus;

namespace UserService.MessageSender.Interfaces
{
    public interface IMessageSender
    {
        void SendMessage(BaseMessage message, string queueName);

    }
}

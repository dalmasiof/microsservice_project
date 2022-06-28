using MessageBus;

namespace MessageQueue
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage baseMessage, string queuename);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBus.RabbitMQSender
{
    public interface IRabbitMQSender
    {
        void SendMessage(BaseMessage message, string queueName);
    }
}

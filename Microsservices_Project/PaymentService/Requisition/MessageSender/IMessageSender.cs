using Entities.Entities;
using PaymentService.ViewModel;

namespace PaymentService.Requisition.MessageSender
{
    public interface IMessageSender
    {
        void SendMessage(PaymentData baseMessage);

    }
}

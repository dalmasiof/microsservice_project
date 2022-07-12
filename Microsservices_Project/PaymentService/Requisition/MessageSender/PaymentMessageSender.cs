using MessageBus;

namespace PaymentService.Requisition.MessageSender
{
    public class PaymentMessageSender
    {
        public long id { get; set; }
        public long idPaymentOrder { get; set; }
        public long idUser { get; set; }
        public double value { get; set; }
        public DateTime paymentDate = DateTime.Now;
    }
}

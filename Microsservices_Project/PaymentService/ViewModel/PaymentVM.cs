namespace PaymentService.ViewModel
{
    public class PaymentVM
    {
        public long id { get; set; }
        public long idPaymentOrder { get; set; }
        public long idUser { get; set; }
        public double value { get; set; }
        public DateTime paymentDate { get; set; }
    }
}

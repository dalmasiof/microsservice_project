namespace PaymentOrderService.ViewModels
{
    public class PoVm
    {
        public long id { get; set; }
        public long userId { get; set; }
        public double total { get; set; }
        public double discount { get; set; }
        public double shippingCost { get; set; }
        public double totalToPay { get; set; }
        public double totalPayed { get; set; }
    }
}

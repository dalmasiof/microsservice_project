using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PaymentOrderData
    {
        public long Id { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double ShippingCost { get; set; }
        public double TotalToPay { get; set; }
        public UserData UserData { get; set; }
    }
}

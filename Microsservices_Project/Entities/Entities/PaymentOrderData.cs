using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PaymentOrderData
    {
        public long id { get; set; }
        public double total { get; set; }
        public double discount { get; set; }
        public double shippingCost { get; set; }
        public double totalToPay { get; set; }
        public long userId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PaymentData
    {
        public long id { get; set; }
        public double  value { get; set; }
        public DateTime paymentDate { get; set; }
        public PaymentOrderData paymentOrderData { get; set; }

        


    }
}

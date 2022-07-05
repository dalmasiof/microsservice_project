using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class PaymentData
    {
        public long Id { get; set; }
        public double  Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentOrderData PaymentOrderData { get; set; }

        


    }
}

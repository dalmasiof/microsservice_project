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
        public long idPaymentOrder { get; set; }
        public long idUser { get; set; }
        public double  value { get; set; }
        public DateTime paymentDate { get; set; }

    }
}

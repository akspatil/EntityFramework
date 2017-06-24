using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PaymentEntity
    {
        public long PayId { get; set; }
        public Nullable<long> StudentId { get; set; }
        public string AmountToPay { get; set; }
        public string Paid { get; set; }
        public string PendingAmount { get; set; }
    }
}

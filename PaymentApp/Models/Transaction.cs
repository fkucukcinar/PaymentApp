using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string MessageType { get; set; }
        public string TransactionId { get; set; }
        public long AccountId { get; set; }
        public string Origin { get; set; }
        public decimal Amount { get; set; }

    }
}

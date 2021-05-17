using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Models
{
    public class Account
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public decimal Balance { get; set; }
      
    }
}

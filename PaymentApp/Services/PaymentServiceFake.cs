using PaymentApp.Contracts;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Services
{
    public class PaymentServiceFake : IPaymentService
    {
        private readonly List<Account> _accounts;
        public PaymentServiceFake()
        {
            _accounts = new List<Account>()
            {
                new Account() { AccountId = 111, Balance = 100 },
                new Account() { AccountId = 222, Balance = 200 },
                new Account() { AccountId = 333, Balance = 300 },
            };
        }
        public BaseResponse MakePayments(string messageType, string transactionId, long accountId, string origin, decimal amount)
        {
            throw new NotImplementedException();
        }

        public List<Account> QueryBalances()
        {
            return _accounts;
        }
    }
}

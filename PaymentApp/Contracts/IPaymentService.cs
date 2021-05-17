using Microsoft.AspNetCore.Mvc;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Contracts
{
    public interface IPaymentService
    {
        BaseResponse MakePayments(string messageType, string transactionId, long accountId, string origin, decimal amount);
        List<Account>  QueryBalances();
    }
}

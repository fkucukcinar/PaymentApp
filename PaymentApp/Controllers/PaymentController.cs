using Microsoft.AspNetCore.Mvc;
using PaymentApp.Contracts;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentService _service;
       
        public PaymentController(IPaymentService service)
        {
            this._service = service;
        }
        
        [HttpPost("makePayments")]
        public BaseResponse MakePayments(string messageType, string transactionId, long accountId, string origin, decimal amount)
        {
            return _service.MakePayments(messageType, transactionId, accountId, origin, amount);
        }
        
        [HttpGet("queryBalances")]
        public List<Account> QueryBalances()
        {
            return _service.QueryBalances();
        }

    }
}

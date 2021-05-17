using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaymentApp.Contracts;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Services
{
    public class PaymentService: BaseService, IPaymentService 
    {
        private IConfiguration _config;
        private readonly PaymentApiContext _context;

        public PaymentService(IConfiguration config, IServiceProvider serviceProvider,PaymentApiContext context) : base(serviceProvider)
        {
            this._config = config;
            this._context = context;
        }

        public BaseResponse MakePayments(string messageType, string transactionId, long accountId, string origin, decimal amount)
        {
            Account account = new Account();
            var response = new BaseResponse();
            try
            {
                using (var trsct = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    account = _context.Account.Where(a => a.AccountId == accountId).FirstOrDefault();
                    if (account != null)
                    {
                        if (messageType == "PAYMENT")
                        {
                            var calculatedAmount = CalculateAmount(origin, amount);
                            account.Balance = account.Balance - calculatedAmount;
                            
                            var transaction = new Transaction();
                            transaction.MessageType = messageType;
                            transaction.TransactionId = transactionId;
                            transaction.AccountId = accountId;
                            transaction.Origin = origin;
                            transaction.Amount = amount;
                            _context.Add(transaction);
                        }
                        else if (messageType == "ADJUSTMENT")
                        {
                            var trs = _context.Transaction.Where(a => a.TransactionId == transactionId).FirstOrDefault();
                            if (trs == null)
                            {
                                response.SetError("No transaction found !");
                                return response;
                            }
                            else
                            {
                                var calculatedAmount = CalculateAmount(trs.Origin, trs.Amount);
                                account.Balance = account.Balance + calculatedAmount;
                            }
                        }
                        else
                        {
                            response.SetError("No message type found !");
                            return response;
                        }
                        _context.SaveChanges();
                        trsct.Commit();
                        response.SetSuccess();
                        return response;
                    }
                    else
                    {
                        response.SetError("No account found");
                        return response;
                    }

                }
            }
            catch (Exception e)
            {
                response.SetError("Unexpected Error.");
                return response;
            }
            
        }
        public decimal CalculateAmount(string origin, decimal amount)
        {
            if (origin == "VISA")
            {
                amount = amount * new decimal(1.01);
            }
            else if (origin == "MASTER")
            {
                amount = amount * new decimal(1.02);
            }
            return amount;
        }
        public List<Account> QueryBalances()
        {
            List<Account> accountList = new List<Account>();
            try
            {
                using (var ctx = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                   accountList = _context.Account.ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return accountList;
        }
    }
}

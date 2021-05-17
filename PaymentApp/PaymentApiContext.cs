using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp
{
    public class PaymentApiContext : DbContext
    {
        public PaymentApiContext(DbContextOptions<PaymentApiContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=PaymentDemo.db");
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentApp.Services
{
  
    public class BaseService
    {
        public IServiceProvider ServiceProvider { get; set; }
        public PaymentApiContext context { get; set; }

        public BaseService(IServiceProvider serviceProvider)
        {
            context = serviceProvider.GetRequiredService<PaymentApiContext>();
            ServiceProvider = serviceProvider;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Strategy
{
    class PayPalPaymentProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine("Payment Successfull");
            return true;
        }
    }
}

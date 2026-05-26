using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Strategy
{
    class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine("Payment Successfull");
            return true;
        }
    }
}

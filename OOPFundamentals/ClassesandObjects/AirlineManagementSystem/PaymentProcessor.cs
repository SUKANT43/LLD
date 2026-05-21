using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class PaymentProcessor
    {

        private static PaymentProcessor instance;

        public PaymentProcessor() { }

        public static PaymentProcessor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentProcessor();
                }
                return instance;
            }
        }

        public void ProcessPayment(Payment payment)
        {
            payment.ProcessPayment();
        }
    }
}

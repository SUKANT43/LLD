using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystem
{
    class Payment
    {
        public string PaymentId { get; }
        public string PaymentMethod { get; }
        public double Amount { get; }
        public PaymentStatus Status { get; private set; }

        public Payment(string paymentId, string paymentMethod, double amount)
        {
            PaymentId = paymentId;
            PaymentMethod = paymentMethod;
            Amount = amount;
            Status = PaymentStatus.PENDING;
        }

        public void ProcessPayment()
        {
            Status = PaymentStatus.COMPLETED;
        }

    }
}

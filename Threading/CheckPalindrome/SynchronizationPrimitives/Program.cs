using System;
using System.Threading;

namespace SynchronizationPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddAmount(1000);

            Console.WriteLine("Initial Balance:");
            bank.GetBalance();

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    bank.WithDraw(1);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    bank.WithDraw(1);
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Expected Balance: 800");
            bank.GetBalance();

            Console.ReadLine();
        }
    }

    class Bank
    {
        private double _balance;
        private static object lockObj = new object();

        public void AddAmount(double amount)
        {
            _balance += amount;
        }

        public void WithDraw(double amount)
        {
            //lock (lockObj)
            //{

            Monitor.Enter(lockObj);
            try
            {
                if (_balance >= amount)
                {
                    double temp = _balance;

                    Thread.Sleep(1);

                    _balance = temp - amount;
                    //}
                }
            }
            finally
            {
                Monitor.Exit(lockObj); 
            }

        }

        public void GetBalance()
        {
            Console.WriteLine($"Balance: {_balance}");
        }
    }
}
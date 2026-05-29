using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning;

            Mutex mutex = new Mutex(true,"MutexDemo",out isRunning);

            if (isRunning)
            {
                Console.WriteLine("Application is running for the first time.");
            }
            else
            {
                Console.WriteLine("Another instance is already running.");
            }

            Console.ReadLine();
        }
    }
}

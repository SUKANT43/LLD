using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        public static void SayHi()
        {
            Console.WriteLine("hi");
        }

        public static void SayHiWithName(object obj)
        {
            Console.WriteLine("hi " + obj);
        }

        //public static void SayNameAndAge(object obj)
        //{
        //    var details =((string, int))obj;
        //    Console.WriteLine("Name: "+details.Item1+", Age: "+details.Item2);
        //}

        static void Main(string[] args)
        {
            //1
            //Thread th = new Thread(()=>SayHi());
            //th.Start();

            //th.Join();

            //Thread.Sleep(1);

            //Console.WriteLine("Task finished");

            //2
            //Thread th = new Thread(SayHi);
            //th.Start();
            //th.Join();

            //Thread th2 = new Thread(SayHiWithName);
            //th2.Start("Sukant");

            //object lockObj = new object();

            //for (int i = 1; i <= 10; i++)
            //{
            //    int temp = i;

            //    ThreadPool.QueueUserWorkItem(_ =>
            //    {
            //        Console.WriteLine(i);
            //    });

            //    Thread.Sleep(2);
            //}


            //Thread t = new Thread(() =>
            //{
            //    Console.WriteLine("A");
            //});

            //t.Start();
            //t.Start();

            //ThreadPool.QueueUserWorkItem(_ =>
            //{
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Task");
            //});

            //Console.WriteLine("Main");

            //Thread t = new Thread(() =>
            //  {
            //      while (true) { }
            //  });
            //t.IsBackground = true;
            //t.Start();

            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("Running...");
                }
            });
            t.Start();
            Thread.Sleep(3000);
            t.Abort();

            Console.ReadLine();
        }
    }
}

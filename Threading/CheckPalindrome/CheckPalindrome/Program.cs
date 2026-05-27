using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "heh hih lwk mam wow huh hell";

            string[] words = word.Split(' ');

            object lockObj = new object();

            //1
            //Parallel.ForEach(words, wor =>
            //{
            //        Console.WriteLine(wor + "=" + IsPalindrome(wor));
            //});


            //2
            //List<Thread> threads = new List<Thread>();

            //foreach (var wor in words)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        Console.WriteLine(wor + "=" + IsPalindrome(wor));
            //    });

            //    threads.Add(thread);
            //    thread.Start();

            //    //thread.Join();
            //}

            //foreach(Thread thread in threads)
            //{
            //    thread.Join();
            //}

            //3

            int threadCount = 3;

            List<Thread> threads = new List<Thread>();

            int currentIndex = 0;
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() =>
                  {
                      while (true)
                      {
                          string currentWord;
                          lock (lockObj)
                          {
                              if (currentIndex >= words.Length)
                                  return;

                              currentWord = words[currentIndex++];
                          }

                          Console.WriteLine(
                              $"Thread {Thread.CurrentThread.ManagedThreadId}: " + $"{currentWord} = {IsPalindrome(currentWord)}");

                          Thread.Sleep(100);

                      }
                  });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }


            Console.ReadLine();

        }

        public static bool IsPalindrome(string word)
        {

            int i = 0;
            int j = word.Length - 1;

            while (i <= j)
            {
                if (word[i++] != word[j--]) return false;
            }

            return true;
        }

    }
}


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
            string word = "heh hih mam wow huh lel jaf mox puz tit baf lol gag tat dax zez nun pip pop mum nan kik sas kek lil juj wax juj kof jyj faf ses fof tut dód gog pep pop sós féf bób mem fuf ror pip tat jéj mum pop xex hih fuf kak rur fof féf pop lul nón fuf pop sós sés pup pop hih fuf gag nan tat tut nun pop gag sés pop tut sis kek pip pop juj sés nan kók lil faf lol mem kak juj pop tut sés gag lul hih pop kek nan sés fuf pop sis dad pop lil pop mem nan pep tut sis pop rar pop mom pop gag lul lil pop fuf mim pop kek tat fuf gag fuf pop lul dad nan sés pip pop kak tut pip pop mem pop gag ses nun dad pop gag sés fuf pip mom dad kek hih pop lol lul fuf pop lul fuf nan sés fuf pop pep pip pop lul pop tat sis hih mom pop tat lul fuf pop pip sis nan pop fuf lul pop gag tut fuf pop lul hih pop gig pip tut pop lul gag hih pop fuf lul pip pop kek dad nan pop gag tut fuf pop lul hih pop gig pip tut pop baf lwk hell met nax rot pes map ket vis lur kof sub tim ped rip tix cud fan wag jet fin cob mud leg dot sun cat hen bit dog run map cap lip sat";
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


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

            Parallel.ForEach(words, wor =>
            {
                Console.WriteLine(wor+"="+IsPalindrome(wor));
            });



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

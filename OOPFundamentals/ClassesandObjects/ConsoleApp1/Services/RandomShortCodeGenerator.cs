using ConsoleApp1.Services.UrlShortener.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class RandomShortCodeGenerator : IShortCodeGenerator
    {
        private readonly Random _random = new Random();

        private const string Characters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateCode()
        {
            char[] code = new char[6];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = Characters[_random.Next(Characters.Length)];
            }

            return new string(code);
        }
    }
}

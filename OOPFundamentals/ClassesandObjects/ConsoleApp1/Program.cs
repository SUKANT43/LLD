using ConsoleApp1.Services;
using ConsoleApp1.Services.UrlShortener.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)

        {
            IShortCodeGenerator generator =
                new RandomShortCodeGenerator();

            UrlShortenerService service =
                new UrlShortenerService(generator);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("===== URL SHORTENER =====");
                Console.WriteLine("1. Shorten URL");
                Console.WriteLine("2. Get Original URL");
                Console.WriteLine("3. Show All URLs");
                Console.WriteLine("4. Exit");
                Console.Write("Choose Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Original URL: ");
                        string originalUrl = Console.ReadLine();

                        string shortUrl =
                            service.CreateShortUrl(originalUrl);

                        Console.WriteLine("Short URL: " + shortUrl);
                        break;

                    case "2":
                        Console.Write("Enter Short Code: ");
                        string code = Console.ReadLine();

                        string original =
                            service.GetOriginalUrl(code);

                        if (original != null)
                        {
                            Console.WriteLine("Original URL: " + original);
                        }
                        else
                        {
                            Console.WriteLine("URL Not Found");
                        }

                        break;

                    case "3":
                        var urls = service.GetAllUrls();

                        foreach (var item in urls)
                        {
                            Console.WriteLine(
                                item.ShortCode +
                                " -> " +
                                item.OriginalUrl);
                        }

                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }

}

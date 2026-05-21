using ConsoleApp1.Models;
using ConsoleApp1.Services.UrlShortener.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class UrlShortenerService
    {
        private readonly List<ShortUrl> _urls;
        private readonly IShortCodeGenerator _codeGenerator;

        public UrlShortenerService(IShortCodeGenerator codeGenerator)
        {
            _urls = new List<ShortUrl>();
            _codeGenerator = codeGenerator;
        }

        public string CreateShortUrl(string originalUrl)
        {
            string code;

            do
            {
                code = _codeGenerator.GenerateCode();
            }
            while (_urls.Any(x => x.ShortCode == code));

            ShortUrl shortUrl = new ShortUrl
            {
                OriginalUrl = originalUrl,
                ShortCode = code
            };

            _urls.Add(shortUrl);

            return "http://short.ly/" + code;
        }

        public string GetOriginalUrl(string shortCode)
        {
            ShortUrl url = _urls
                .FirstOrDefault(x => x.ShortCode == shortCode);

            return url?.OriginalUrl;
        }

        public List<ShortUrl> GetAllUrls()
        {
            return _urls;
        }
    }

}

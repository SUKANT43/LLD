using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    namespace UrlShortener.Services
    {
        public interface IShortCodeGenerator
        {
            string GenerateCode();
        }
    }
}

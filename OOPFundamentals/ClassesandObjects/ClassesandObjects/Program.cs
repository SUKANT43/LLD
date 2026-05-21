using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Car corolla = new Car("Toyota", "Corolla");
            Car mustang = new Car("Ford", "Mustang");

            corolla.Accelerate(20);
            mustang.Accelerate(40);

            corolla.DisplayStatus();
            Console.WriteLine("-----------------");
            mustang.DisplayStatus();

            Console.ReadLine();
        }
    }
}

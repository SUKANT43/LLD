using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesandObjects
{
    class Car
    {
        private string brand;
        private string model;
        private int speed;

        public Car(string brand,string model)
        {
            this.brand = brand;
            this.model = model;
            this.speed = 0;
        }

        public void Accelerate(int increment)
        {
            speed += increment;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{brand} is running at {speed} km/h.");
        }
    }
}

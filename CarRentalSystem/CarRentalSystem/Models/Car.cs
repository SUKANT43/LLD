using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private string licensePlate;
        private double rentalPricePerDay;
        private bool avilable;

        public Car(string make,string model,int year,string licensePlate, double rentalPricePerDay)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.licensePlate = licensePlate;
            this.rentalPricePerDay = rentalPricePerDay;
            avilable = true;
        }

        public double GetRentalPricePerDay() => rentalPricePerDay;
        public string GetLicensePlate() => licensePlate;
        public string GetMake() => make;
        public string GetModel() => model;
        public bool IsAvilable() => avilable;

        public void SetAvilable(bool avilable)
        {
            this.avilable = avilable;
        }
        
    }
}

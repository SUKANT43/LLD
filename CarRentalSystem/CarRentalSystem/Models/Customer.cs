using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    class Customer
    {
        private string name;
        private string contactInfo;
        private string driversLicenseNumber;

        public Customer(string name,string contactInfo,string driversLicenseNumber)
        {
            this.name = name;
            this.contactInfo = contactInfo;
            this.driversLicenseNumber = driversLicenseNumber;
        }
    }
}

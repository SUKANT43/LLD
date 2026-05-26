using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Observer
{
    class User
    {
        private string id;
        private string email;
        private string name;

        public User(string email,string name)
        {
            id = Guid.NewGuid().ToString();
            this.email = email;
            this.name = name;
        }

        public string GetId => id;
        public string GetEmail => email;
        public string GetName => name;
    }
}

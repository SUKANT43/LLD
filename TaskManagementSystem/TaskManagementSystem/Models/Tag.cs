using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    class Tag
    {
        private string name;
        public Tag(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}

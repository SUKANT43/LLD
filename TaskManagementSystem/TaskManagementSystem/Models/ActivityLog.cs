using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    class ActivityLog
    {
        private readonly string description;
        private readonly DateTime timeStamp;


        public ActivityLog(string description)
        {
            this.description = description;
            timeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{timeStamp}] {description}";
        }
    }
}

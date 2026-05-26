using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Observer
{
    class ActivityLogger : ITaskObserver
    {
        public void Update(TaskM task, string changeType)
        {
            Console.WriteLine($"LOGGER: Task '{task.GetTitle}' was updated. Change: {changeType}");
        }
    }
}

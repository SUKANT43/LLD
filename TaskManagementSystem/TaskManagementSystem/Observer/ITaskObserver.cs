using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Observer
{
    interface ITaskObserver
    {
         void Update(TaskM task, string log);
    }
}

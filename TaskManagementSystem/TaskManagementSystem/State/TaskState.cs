using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.State
{
    abstract class TaskState
    {
        public abstract void StartProgress(TaskM task);
        public abstract TaskStat GetStatus();
        public abstract void ReopenTask(TaskM task);
        public abstract void CompleteTask(TaskM task);
    }
}

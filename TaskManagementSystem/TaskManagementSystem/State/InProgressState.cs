using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.State
{
    class InProgressState : TaskState
    {
        public override void CompleteTask(TaskM task)
        {
            task.SetState(new DoneState());
        }

        public override TaskStat GetStatus()
        {
            return TaskStat.IN_PROGRESS;
        }

        public override void ReopenTask(TaskM task)
        {
            task.SetState(new ToDoState());
        }

        public override void StartProgress(TaskM task)
        {
            Console.WriteLine("Task is already in progress.");
        }
    }
}

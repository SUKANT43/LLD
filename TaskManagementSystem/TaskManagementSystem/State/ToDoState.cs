using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Enums;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.State
{
    class ToDoState : TaskState
    {
        public override void CompleteTask(TaskM task)
        {
            Console.WriteLine("Cannot complete a task that is not in progress.");
        }

        public override TaskStat GetStatus()
        {
            return TaskStat.TODO;
        }

        public override void ReopenTask(TaskM task)
        {
            Console.WriteLine("Task is already in TO-DO state.");
        }

        public override void StartProgress(TaskM task)
        {
            task.SetState(new InProgressState());
        }
    }
}

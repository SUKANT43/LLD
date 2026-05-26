using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementSystem.Enums;
using TaskManagementSystem.Models;
namespace TaskManagementSystem.State
{
    class DoneState : TaskState
    {
        public override void CompleteTask(TaskM task)
        {
            Console.WriteLine("Task is already done.");
        }

        public override TaskStat GetStatus()
        {
            return TaskStat.DONE;
        }

        public override void ReopenTask(TaskM task)
        {
            task.SetState(new ToDoState());
        }

        public override void StartProgress(TaskM task)
        {
            Console.WriteLine("Cannot start a completed task. Reopen it first.");
        }
    }
}

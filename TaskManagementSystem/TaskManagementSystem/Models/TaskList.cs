using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    class TaskList
    {
        private string id;
        private List<TaskM> tasks;
        private string name;
        private readonly object lockObj = new object();

        public TaskList(string name)
        {
            id = Guid.NewGuid().ToString();
            tasks = new List<TaskM>();
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine($"--- Task List: {name} ---");
            foreach (var task in tasks)
            {
                task.Display("");
            }
            Console.WriteLine("-----------------------------------");
        }

        public List<TaskM> GetTasks()
        {
            lock (lockObj)
            {
                return new List<TaskM>(tasks); 
            }
        }

        public string GetId() => id;
        public string GetName() => name;

        public void AddTask(TaskM task)
        {
            lock (lockObj)
            {
                tasks.Add(task);
            }
        }

    }
}

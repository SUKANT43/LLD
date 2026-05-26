using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Strategy
{
    class SortByDueDate : ITaskSortStrategy
    {
        public void Sort(List<TaskM> tasks)
        {
            tasks.Sort((a, b) => string.Compare(a.GetDueDate(), b.GetDueDate(), StringComparison.Ordinal));
        }
    }
}

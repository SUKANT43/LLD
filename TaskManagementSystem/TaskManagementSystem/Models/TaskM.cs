using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Enums;
using TaskManagementSystem.Observer;
using TaskManagementSystem.State;

namespace TaskManagementSystem.Models
{
    class TaskM
    {
        private string id;
        private List<TaskM> subTasks;

        public object GetPriority() => priority;
        public string GetDueDate() => dueDate;

        private TaskState currentState;
        private List<ActivityLog> activityLogs;
        private HashSet<Tag> tags;
        private string description;
        private List<ITaskObserver> observers;
        private User createdBy;
        private string dueDate;
        private User assignee;
        private List<Comment> comments;
        private string title;
        private TaskPriority priority;
        private static readonly object taskLock = new object();

        public TaskM(TaskBuilder builder)
        {
            this.id = builder.Id;
            this.title = builder.Title;
            this.description = builder.Description;
            this.dueDate = builder.DueDate;
            this.priority = builder.Priority;
            this.createdBy = builder.CreatedBy;
            this.assignee = builder.Assignee;
            this.tags = builder.Tags;
            this.currentState = new ToDoState(); 
            this.comments = new List<Comment>();
            this.subTasks = new List<TaskM>();
            this.activityLogs = new List<ActivityLog>();
            this.observers = new List<ITaskObserver>();
            AddLog($"Task created with title: {title}");
        }

        public void AddSubtask(TaskM subtask)
        {
            lock (taskLock)
            {
                subTasks.Add(subtask);
                AddLog($"Subtask added: {subtask.GetTitle}");
                NotifyObservers("subtask_added");
            }
        }

        public void SetAssignee(User user)
        {
            lock (taskLock)
            {
                this.assignee = user;
                AddLog($"Assigned to {user.GetName}");
                NotifyObservers("assignee");
            }
        }

        public string GetId => id;

        public string GetDescription => description;

        public User GetAssignee() => assignee;

        public string GetTitle => title;

        public void AddObserver(ITaskObserver observer) => observers.Add(observer);

        public void StartProgress() => currentState.StartProgress(this);

        public void RemoveObserver(ITaskObserver observer) => observers.Remove(observer);

        public TaskStat GetStatus() => currentState.GetStatus();

        public void ReopenTask() => currentState.ReopenTask(this);

        public void UpDatePriority(TaskPriority priority)
        {
            lock (taskLock)
            {
                this.priority = priority;
            }
        }

        public void AddComment(Comment comment)
        {
            lock (taskLock)
            {
                comments.Add(comment);
            }
        }

        public void AddSubTask(TaskM task)
        {
            lock (taskLock)
            {
                subTasks.Add(task);
            }
        }

        public void CompleteTask()
        {
            currentState.CompleteTask(this);
        }

        public void AddLog(string log)
        {
            activityLogs.Add(new ActivityLog(log));
        }

        public bool IsComposite() => subTasks.Count > 0;

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}- {title} [{GetStatus()}, {priority}, Due: {dueDate}]");
            if (IsComposite())
            {
                foreach (var subtask in subTasks)
                {
                    subtask.Display(indent + "  ");
                }
            }
        }

        public void NotifyObservers(string changeType)
        {
            foreach (var observer in observers)
            {
                observer.Update(this, changeType);
            }
        }

        public void SetState(TaskState state)
        {
            this.currentState = state;
            AddLog($"Status changed to: {state.GetStatus()}");
            NotifyObservers("status");
        }
    }

    class TaskBuilder
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; } = "";
        public string DueDate { get; private set; }
        public TaskPriority Priority { get; private set; }
        public User CreatedBy { get; private set; }
        public User Assignee { get; private set; }
        public HashSet<Tag> Tags { get; private set; } = new HashSet<Tag>();

        public TaskBuilder(string title)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Title = title;
        }

        public TaskBuilder SetDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public TaskBuilder SetDueDate(string dueDate)
        {
            this.DueDate = dueDate;
            return this;
        }

        public TaskBuilder SetPriority(TaskPriority priority)
        {
            this.Priority = priority;
            return this;
        }

        public TaskBuilder SetAssignee(User assignee)
        {
            this.Assignee = assignee;
            return this;
        }

        public TaskBuilder SetCreatedBy(User createdBy)
        {
            this.CreatedBy = createdBy;
            return this;
        }

        public TaskBuilder SetTags(HashSet<Tag> tags)
        {
            this.Tags = tags;
            return this;
        }

        public TaskM Build()
        {
            return new TaskM(this);
        }
    }

}

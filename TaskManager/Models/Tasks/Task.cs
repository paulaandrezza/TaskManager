using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enum;
using TaskManager.Models.Users;
using TaskManager.Service;

namespace TaskManager.Models.Tasks
{
    internal class Task
    {
        public int TaskId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? Deadline { get; set; }
        public Enum.TaskStatus Status { get; set; }

        public User Creator { get; private set; }
        public User Assignee { get; set; }
        public List<Task> RelatedTasks { get; set; }

        private static int TaskIdCounter = 1;

        public Task(string title, string description, User creator)
        {
            TaskId = GenerateUniqueId.Generate(TaskIdCounter);
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            StartTime = null;
            Deadline = null;
            Status = Enum.TaskStatus.NotStarted;
        }
    }
}

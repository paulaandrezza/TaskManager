using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enum;
using TaskManager.Models.Users;
using TaskManager.Service;

namespace TaskManager.Models.Task
{
    internal class ProjectTask
    {
        public int TaskId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? Deadline { get; set; }
        public Enum.TaskStatus Status { get; set; }

        public User Responsible { get; set; }
        public User Assignee { get; set; }
        public List<ProjectTask>? RelatedTasks { get; set; }

        private static int TaskIdCounter = 1;

        public ProjectTask(string title, string description, User responsible, User assigne)
        {
            TaskId = GenerateUniqueId.Generate(TaskIdCounter);
            Title = title;
            Description = description;
            Responsible = responsible;
            Assignee = assigne;
            CreatedAt = DateTime.Now;
            StartTime = null;
            Deadline = null;
            Status = Enum.TaskStatus.NotStarted;
        }
    }
}

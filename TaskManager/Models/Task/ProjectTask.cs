﻿using System;
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

        public ProjectTask(string title, string description, User responsible, User assigne, Enum.TaskStatus status)
        {
            TaskId = GenerateUniqueId.Generate(TaskIdCounter);
            Title = title;
            Description = description;
            Responsible = responsible;
            Assignee = assigne;
            Status = status;
            CreatedAt = DateTime.Now;
            StartTime = null;
            Deadline = null;
        }

        public void SetSchedule(DateTime startTime, DateTime deadline)
        {
            if (Responsible == null || Responsible is TechLead)
            {
                StartTime = startTime;
                Deadline = deadline;
                Console.WriteLine("Cronograma definido com sucesso!");
            }
            else
            {
                Console.WriteLine("Você não tem permissão para definir o cronograma desta tarefa.");
            }
        }

        public void SetStatus(Enum.TaskStatus status)
        {
            Status = status;
        }
    }
}

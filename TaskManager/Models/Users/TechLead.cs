﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enum;
using TaskManager.Models.Task;
using TaskManager.Service;
using TaskManager.UI;

namespace TaskManager.Models.Users
{
    internal class TechLead : User, IUser
    {
        public TechLead(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                string[] techLeadMenu = { "Visualizar Tarefas", "Cadastrar Tarefa", "Assumir Tarefa", "Definir Prazo", "Estatísticas", "Deslogar" };
                Menu options = new Menu(techLeadMenu);
                int selected = options.ShowMenu(title: Title.HelloTechLead());
                continueMenu = SelectedChoice(selected);
                Menu.WaitInput();
            }
        }

        private bool SelectedChoice(int selected)
        {
            switch (selected)
            {
                case 0:
                    ViewTasks();
                    return true;
                case 1:
                    TaskRepository.CreateTask(this);
                    return true;
                case 2:
                    TakeTask(this);
                    return true;
                case 3:
                    TaskRepository.SetTaskSchedule(this);
                    return true;
                case 4:
                    Statistics();
                    return true;
                case 5:
                    return false;
                default:
                    return false;
            }
        }

        private static void TakeTask(TechLead techLead)
        {
            ProjectTask? selectedTask = TaskRepository.ListTasks(techLead, false);

            if (selectedTask != null)
            {
                Console.WriteLine("Escolha uma tarefa para assumir:");
                selectedTask.Responsible = techLead;
                selectedTask.SetStatus(Models.Enum.TaskStatus.NotStarted);
                Console.WriteLine($"Tarefa '{selectedTask.Title}' assumida por {techLead.Name}.");
            }
            else
                Console.WriteLine("Nenhuma tarefa disponível para assumir.");
        }

        private void Statistics()
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                string[] StatisticsMenu = { "Tarefas em Atraso", "Tarefas Não Iniciadas", "Tarefas Concluídas", "Tarefas Abandonadas", "Tarefas Em Progresso", "Tarefas com Impedimento", "Tarefas Aguardando Aprovação", "Alterar Status de uma Tarefa", "Voltar" };
                Menu options = new Menu(StatisticsMenu);
                int selected = options.ShowMenu(title: Title.HelloTechLead());
                continueMenu = StatisticsSelectedChoice(selected);
                Menu.WaitInput();
            }
        }

        private bool StatisticsSelectedChoice(int selected)
        {
            switch (selected)
            {
                case 0:
                    ViewTasksOverdue();
                    return true;
                case 1:
                    ViewTasksWithStatus(Enum.TaskStatus.NotStarted);
                    return true;
                case 2:
                    ViewTasksWithStatus(Enum.TaskStatus.Completed);
                    return true;
                case 3:
                    ViewTasksWithStatus(Enum.TaskStatus.Abandoned);
                    return true;
                case 4:
                    ViewTasksWithStatus(Enum.TaskStatus.InProgress);
                    return true;
                case 5:
                    ViewTasksWithStatus(Enum.TaskStatus.HasIssues);
                    return true;
                case 6:
                    ViewTasksWithStatus(Enum.TaskStatus.NeedsApproval);
                    return true;
                case 7:
                    ChangeTaskStatus(this);
                    return true;
                case 8:
                    return false;
                default:
                    return false;
            }
        }

        private void ViewTasksOverdue()
        {
            List<ProjectTask> tasksOverdue = TaskRepository.GetTasksOverdue();

            if (tasksOverdue.Count == 0)
                Console.WriteLine("Não há tarefas em atraso.");
            else
            {
                Console.WriteLine("Tarefas em Atraso:");
                foreach (var task in tasksOverdue)
                    TaskRepository.PrintTaskDetails(task);
            }
        }

        private void ViewTasksWithStatus(Enum.TaskStatus status)
        {
            var tasks = Program.AllTasks.Where(task => task.Status == status).ToList();
            string statusMessage = status.GetStatusInPortuguese();

            if (tasks.Count == 0)
                Console.WriteLine($"Nenhuma tarefa {statusMessage} encontrada.");
            else
            {
                Console.WriteLine($"Tarefas {statusMessage}:");
                foreach (var task in tasks)
                    TaskRepository.PrintTaskDetails(task);
            }
        }

        private void ChangeTaskStatus(TechLead techLead)
        {
            ProjectTask? selectedTask = TaskRepository.ListTasks(techLead);

            if (selectedTask != null)
            {
                Console.WriteLine("Escolha uma tarefa para alterar o status:");
                Console.WriteLine($"Status atual da Tarefa {selectedTask.TaskId}: {selectedTask.Status.GetStatusInPortuguese()}");
                Models.Enum.TaskStatus? newStatus = TaskRepository.ChooseTaskStatus();
                if (newStatus.HasValue)
                    selectedTask.SetStatus(newStatus.Value);
            }
            else
                Console.WriteLine("Nenhuma tarefa disponível para alterar o status. Lembre-se, você só pode alterar o status de uma tarefa a qual você é o Responsável.");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enum;
using TaskManager.Models.Task;
using TaskManager.Models.Users;
using TaskManager.UI;

namespace TaskManager.Service
{
    internal class TaskRepository
    {
        public static void CreateTask(User creator, User assigne = null)
        {
            Console.WriteLine("Cadastro de Nova Tarefa:");

            string title = Utils.ReadString("Título: ");
            string description = Utils.ReadString("Descrição: ");
            ProjectTask newTask;

            if (creator is TechLead)
            {
                List<User> developers = Program.AllUsers.Where(u => u is Developer).ToList();
                string[] developersNames = developers.Select(u => u.Name).ToArray();
                Menu options = new Menu(developersNames);
                int selectedIndex = options.ShowMenu("Selecione um desenvolvedor: ");
                assigne = developers[selectedIndex];
                newTask = new ProjectTask(title, description, creator, assigne, Models.Enum.TaskStatus.NotStarted);
            } else
                newTask = new ProjectTask(title, description, creator, assigne, Models.Enum.TaskStatus.NeedsApproval);
            Program.AllTasks.Add(newTask);
            Console.WriteLine("Tarefa cadastrada com sucesso!");
        }

        public static void ShowTasks(User user)
        {
            Console.WriteLine("Visualizar Tarefas:");

            if (user is TechLead)
            {
                foreach (var task in Program.AllTasks)
                    PrintTaskDetails(task);
            }
            else
            {
                var userTasks = Program.AllTasks.Where(task => task.Assignee == user).ToList();

                if (userTasks.Count == 0)
                    Console.WriteLine("Sem tarefas cadastradas.");
                else
                {
                    foreach (var task in userTasks)
                        PrintTaskDetails(task);
                }
            }
        }

        public static void PrintTaskDetails(ProjectTask task)
        {
            Console.WriteLine($"Task ID: {task.TaskId}");
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Descrição: {task.Description}");
            Console.WriteLine($"Status: {task.Status.GetStatusInPortuguese()}");
            Console.WriteLine($"Desenvolvedor: {task.Assignee.Name}");
            Console.WriteLine($"Responsável: {task.Responsible.Name}");
            Console.WriteLine($"Criada em: {task.CreatedAt}");
            Console.WriteLine($"Ínicio: {task.StartTime}");
            Console.WriteLine($"Prazo final: {task.Deadline}\n");
        }

        private static List<ProjectTask> GetAvailableTasksForTechLead(TechLead techLead, bool techLeaderIsResponsible = true)
        {
            if (techLeaderIsResponsible)
                return Program.AllTasks
                    .Where(task => task.Responsible == techLead)
                    .ToList();
            else
                return Program.AllTasks
                    .Where(task => (task.Status == Models.Enum.TaskStatus.NotStarted || task.Status == Models.Enum.TaskStatus.NeedsApproval) && task.Responsible != techLead)
                    .ToList();
        }

        public static ProjectTask? ListTasks(TechLead techLead, bool techLeaderIsResponsible = true)
        {
            var availableTasks = GetAvailableTasksForTechLead(techLead, techLeaderIsResponsible);

            if (availableTasks.Count == 0)
                return null;

            string[] taskMenu = availableTasks.Select(task => $"ID: {task.TaskId}, Título: {task.Title}, Desenvolvedor: {task.Assignee.Name}").ToArray();
            Menu taskOptions = new Menu(taskMenu);

            int selectedTaskIndex = taskOptions.ShowMenu();

            if (selectedTaskIndex >= 0 && selectedTaskIndex < availableTasks.Count)
            {
                ProjectTask selectedTask = availableTasks[selectedTaskIndex];
                return selectedTask;
            }
            else
                Console.WriteLine("Opção inválida.");
            
            return null;
        }

        public static Models.Enum.TaskStatus? ChooseTaskStatus()
        {
            Console.WriteLine("Escolha um novo status:");

            var statusOptions = Enum.GetValues(typeof(Models.Enum.TaskStatus))
                            .Cast<Models.Enum.TaskStatus>()
                            .ToArray();

            string[] statusMenuOptions = statusOptions.Select(status => status.GetStatusInPortuguese()).ToArray();
            Menu statusMenu = new Menu(statusMenuOptions);

            int selectedStatusIndex = statusMenu.ShowMenu();

            if (selectedStatusIndex >= 0 && selectedStatusIndex < statusOptions.Length)
                return statusOptions[selectedStatusIndex];

            Console.WriteLine("Opção inválida. O status será mantido inalterado.");
            return null;
        }

        public static void SetTaskSchedule(TechLead techLead)
        {
            Console.WriteLine("Definir Cronograma de Tarefa:");

            var availableTasks = GetAvailableTasksForTechLead(techLead);

            if (availableTasks.Count > 0)
            {
                string[] tasksMenu = availableTasks.Select(task => $"{task.TaskId}: {task.Title}").ToArray();
                Menu tasksMenuOptions = new Menu(tasksMenu);

                int selectedTaskIndex = tasksMenuOptions.ShowMenu("Selecione a tarefa para definir o cronograma:");

                if (selectedTaskIndex >= 0 && selectedTaskIndex < availableTasks.Count)
                {
                    var selectedTask = availableTasks[selectedTaskIndex];

                    var startTime = Utils.ReadDateTime("Digite a data de início (yyyy-MM-dd HH:mm:ss): ");
                    var deadline = Utils.ReadDateTime("Digite o prazo final (yyyy-MM-dd HH:mm:ss): ");

                    selectedTask.SetSchedule(startTime, deadline);
                }
                else
                {
                    Console.WriteLine("Opção de tarefa inválida.");
                }
            }
            else
            {
                Console.WriteLine("Não há tarefas disponíveis para definir o cronograma.");
            }
        }

        public static List<ProjectTask> GetTasksOverdue()
        {
            DateTime currentDate = DateTime.Now;

            return Program.AllTasks
                .Where(task => task.Deadline.HasValue && task.Deadline < currentDate && task.Status != Models.Enum.TaskStatus.Completed)
                .ToList();
        }

        public static void ChangeTaskStatus(ProjectTask task, Models.Enum.TaskStatus newStatus)
        {
            if (task != null)
            {
                task.Status = newStatus;
                Console.WriteLine($"Status da Tarefa {task.TaskId} alterado para {newStatus.GetStatusInPortuguese()}");
            }
            else
                Console.WriteLine("Tarefa não encontrada.");

            Menu.WaitInput();
        }
    }
}

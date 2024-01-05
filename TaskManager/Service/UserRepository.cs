using System;
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
    internal class UserRepository
    {
        public static List<User> Users()
        {
            return new List<User>
        {
            new TechLead("Carol", "carol", "12345678"),
            new Developer("Paula", "paula", "12345678"),
            new Developer("Vitória", "vitoria", "12345678")
        };
        }
        public static void ShowUsers()
        {
            Console.WriteLine("Users:");

            foreach (var user in Users())
            {
                Console.WriteLine("\n" + user.ToString());
            }
        }

        public static void CreateTask(User creator, User assigne = null)
        {
            Console.WriteLine("Cadastro de Nova Tarefa:");

            string title = Utils.ReadString("Título: ");
            string description = Utils.ReadString("Descrição: ");

            if (creator is TechLead)
            {
                List<User> developers = Program.AllUsers.Where(u => u is Developer).ToList();
                string[] developersNames = developers.Select(u => u.Name).ToArray();
                Menu options = new Menu(developersNames);
                int selectedIndex = options.ShowMenu("Selecione um desenvolvedor: ");
                assigne = developers[selectedIndex];
            }

            ProjectTask newTask = new ProjectTask(title, description, creator, assigne);
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

        private static void PrintTaskDetails(ProjectTask task)
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
                    .Where(task => task.Status == Models.Enum.TaskStatus.NotStarted && task.Responsible == techLead)
                    .ToList();
            else
                return Program.AllTasks
                    .Where(task => task.Status == Models.Enum.TaskStatus.NotStarted && task.Responsible != techLead)
                    .ToList();
        }

        public static void TakeTask(TechLead techLead)
        {
            Console.WriteLine("Escolha uma tarefa para assumir:");

            var availableTasks = GetAvailableTasksForTechLead(techLead, false);

            if (availableTasks.Count == 0)
            {
                Console.WriteLine("Não há tarefas disponíveis para assumir no momento.");
                return;
            }

            string[] taskMenu = availableTasks.Select(task => $"ID: {task.TaskId}, Título: {task.Title}").ToArray();
            Menu taskOptions = new Menu(taskMenu);

            int selectedTaskIndex = taskOptions.ShowMenu();

            if (selectedTaskIndex >= 0 && selectedTaskIndex < availableTasks.Count)
            {
                ProjectTask selectedTask = availableTasks[selectedTaskIndex];
                selectedTask.Responsible = techLead;

                Console.WriteLine($"Tarefa '{selectedTask.Title}' assumida por {techLead.Name}.");
            }
            else
                Console.WriteLine("Opção inválida.");
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

    }
}

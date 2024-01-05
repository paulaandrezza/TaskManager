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
            Menu.WaitInput();
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

            Menu.WaitInput();
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
    }
}

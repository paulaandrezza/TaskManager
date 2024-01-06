using System;
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
                string[] StatisticsMenu = { "Tarefas em atraso", "Tarefas Concluídas", "Tarefas Abandonadas", "Tarefas com Impedimento", "Tarefas em Análise", "Tarefas a serem Aprovadas", "Alterar Status de uma Tarefa", "Voltar" };
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
                    ViewCompletedTasks();
                    return true;
                case 2:
                    return true;
                case 3:
                    return true;
                case 4:
                    return true;
                case 5:
                    return true;
                case 6:
                    ChangeTaskStatus(this);
                    return true;
                case 7:
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

        private void ViewCompletedTasks()
        {
            var completedTasks = Program.AllTasks.Where(task => task.IsCompleted()).ToList();

            if (completedTasks.Count == 0)
                Console.WriteLine("Nenhuma tarefa concluída encontrada.");
            else
            {
                Console.WriteLine("Tarefas Concluídas:");
                foreach (var task in completedTasks)
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
                Console.WriteLine("Nenhuma tarefa disponível para alterar o status.");
        }
    }
}

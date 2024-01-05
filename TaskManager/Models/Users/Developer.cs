using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Task;
using TaskManager.Service;
using TaskManager.UI;

namespace TaskManager.Models.Users
{
    internal class Developer : User, IUser
    {
        public Developer(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                string[] developerMenu = { "Cadastrar Tarefa", "Visualizar Tarefas", "Deslogar" };
                Menu options = new Menu(developerMenu);

                Console.Clear();
                int selected = options.ShowMenu(Title.HelloDeveloper());
                continueMenu = SelectedChoice(selected);
            }
        }

        private bool SelectedChoice(int selected)
        {
            switch (selected)
            {
                case 0:
                    CreateTask();
                    return true;
                case 1:
                    ViewTasks();
                    return true;
                case 2:
                    return false;
                default:
                    return false;
            }
        }

        private void CreateTask()
        {
            Console.WriteLine("Cadastro de Nova Tarefa:");

            string title = Utils.ReadString("Título: ");
            string description = Utils.ReadString("Descrição: ");

            ProjectTask newTask = new ProjectTask(title, description, this, this);
            Program.AllTasks.Add(newTask);

            Console.WriteLine("Tarefa cadastrada com sucesso!");
            Console.ReadKey();
        }

        private void ViewTasks()
        {
            UserRepository.ShowTasks(this);
        }
    }
}

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
                int selected = options.ShowMenu(Title.HelloDeveloper());
                continueMenu = SelectedChoice(selected);
                Menu.WaitInput();
            }
        }

        private bool SelectedChoice(int selected)
        {
            switch (selected)
            {
                case 0:
                    TaskRepository.CreateTask(this, this);
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
    }
}

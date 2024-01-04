using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Users
{
    internal class Developer : User, IUser
    {
        public Developer(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            DeveloperMenu();
        }

        private void DeveloperMenu()
        {
            string[] developerMenu = { "Cadastrar Tarefa", "Visualizar Tarefas" };
            Menu options = new Menu(developerMenu);

            while (true)
            {
                Console.Clear();
                int selected = options.ShowMenu(Title.HelloDeveloper());
                if (SelectedChoice(selected))
                    break;
            }
        }

        private bool SelectedChoice(int selected)
        {
            switch (selected)
            {
                case 0:
                    return true;
                case 1:
                    return true;
                default:
                    return false;
            }
        }
    }
}

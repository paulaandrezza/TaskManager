using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.UI;

namespace TaskManager.Models.Users
{
    internal class TechLead : User, IUser
    {
        public TechLead(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            TechLeadMenu();
        }

        private void TechLeadMenu()
        {
            string[] techLeadMenu = { "Visualizar Tarefas", "Cadastrar Tarefa", "Assumir Tarefa", "Estatísticas" };
            Menu options = new Menu(techLeadMenu);

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
                case 2:
                    return true;
                case 3:
                    return true;
                default:
                    return false;
            }
        }
    }
}

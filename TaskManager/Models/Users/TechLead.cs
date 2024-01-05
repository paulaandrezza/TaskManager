using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    UserRepository.CreateTask(this);
                    return true;
                case 2:
                    UserRepository.TakeTask(this);
                    return true;
                case 3:
                    UserRepository.SetTaskSchedule(this);
                    return true;
                case 4:
                    return true;
                case 5:
                    return false;
                default:
                    return false;
            }
        }
    }
}

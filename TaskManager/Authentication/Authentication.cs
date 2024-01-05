using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Users;
using TaskManager.UI;

namespace TaskManager.Authentication
{
    internal class Authentication
    {
        public static User? PerformAuthentication(List<User> users)
        {
            while(true)
            {
                Console.Clear();
                Console.Write("Digite o username: ");
                string username = Console.ReadLine();
                Console.Write("Digite a senha: ");
                string password = Console.ReadLine();
                var user = users.Find(f => f.Username == username);
                if (ValidateUser(user, password))
                {
                    return user;
                    break;
                }
            }
        }

        private static bool ValidateUser(User? user, string password)
        {
            if (user != null && user.Password == password)
            {
                user.Greet();
                return true;
            }
            else
            {
                Console.WriteLine("Username e/ou senha Incorretos. Tente novamente!");
                Menu.WaitInput();
                return false;
            }
        }
    }
}

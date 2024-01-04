using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Users;

namespace TaskManager.Authentication
{
    internal class Authentication
    {
        public static User? PerformAuthentication(List<User> users)
        {
            Console.Clear();
            Console.Write("Digite o username: ");
            string username = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string password = Console.ReadLine();
            var user = users.Find(f => f.Username == username);
            ValidateUser(user, password);
            return user;
        }

        private static void ValidateUser(User? user, string password)
        {
            if (user != null && user.Password == password)
            {
                user.Greet();
            }
            else
            {
                Console.WriteLine("Username e/ou senha Incorretos. Tente novamente!");
                Menu.WaitInput();
            }
        }
    }
}

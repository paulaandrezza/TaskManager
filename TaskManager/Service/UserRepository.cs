using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Users;

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
    }
}

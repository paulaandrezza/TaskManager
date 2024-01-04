using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Users
{
    internal class Developer : User, IUser
    {
        public Developer(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            Console.WriteLine("\nOlá desenvolvedor");
        }
    }
}

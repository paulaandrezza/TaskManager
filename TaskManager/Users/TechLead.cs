using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Users
{
    internal class TechLead : User, IUser
    {
        public TechLead(string name, string username, string password) : base(name, username, password) { }

        public override void Greet()
        {
            Console.WriteLine("\nOlá TechLead");
        }
    }
}

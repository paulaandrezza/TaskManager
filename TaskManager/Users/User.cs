﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Users
{
    internal abstract class User : IUser
    {
        public string Name { get; private set; }
        public string Username {  get; protected set; }
        public string Password { get; set; }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        public abstract void Greet();
    }
}

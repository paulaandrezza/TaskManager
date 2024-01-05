﻿using TaskManager.Models.Users;
using TaskManager.Service;
using TaskManager.UI;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    User user = Authentication.Authentication.PerformAuthentication(UserRepository.Users());
                    Menu.WaitInput();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

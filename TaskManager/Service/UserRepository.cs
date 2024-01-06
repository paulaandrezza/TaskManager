using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Enum;
using TaskManager.Models.Task;
using TaskManager.Models.Users;
using TaskManager.UI;

namespace TaskManager.Service
{
    internal class UserRepository
    {
        private static string DevelopersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Service", "developers.csv");

        public static List<User> LoadDevelopersFromFile()
        {
            List<User> users = new List<User>();
            try
            {
                if (File.Exists(DevelopersFilePath))
                {
                    string[] lines = File.ReadAllLines(DevelopersFilePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            string name = parts[1].Trim();
                            string username = parts[2].Trim();
                            string password = parts[3].Trim();

                            if (parts[0] == "TechLead")
                                users.Add(new TechLead(name, username, password));
                            else if (parts[0] == "Developer")
                                users.Add(new Developer(name, username, password));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo de desenvolvedores: {ex.Message}");
            }

            return users;
        }
    }
}

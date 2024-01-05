using TaskManager.Models.Task;
using TaskManager.Models.Users;
using TaskManager.Service;
using TaskManager.UI;

namespace TaskManager
{
    internal class Program
    {
        public static List<ProjectTask> AllTasks = new List<ProjectTask>();
        public static List<User> AllUsers = new List<User>(UserRepository.Users());
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    User user = Authentication.Authentication.PerformAuthentication(AllUsers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

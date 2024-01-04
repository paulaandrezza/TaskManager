using TaskManager.Models.Users;
using TaskManager.Service;

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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

using TaskManager.Service;
using TaskManager.Users;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = Authentication.Authentication.PerformAuthentication(UserRepository.Users());
        }
    }
}

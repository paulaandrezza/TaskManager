using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UI
{
    internal class Utils
    {
        public static string ReadString(string prompt)
        {
            string inputString;

            while (true)
            {
                Console.Write(prompt);
                inputString = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputString))
                    return inputString;
                else
                {
                    Console.WriteLine("Esse valor não pode ser vazio. Tente novamente.");
                    Menu.WaitInput();
                }
            }
        }
    }
}

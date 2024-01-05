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

        public static int ReadInteger(string prompt)
        {
            int result;

            do
            {
                Console.Write(prompt + " ");
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result;
        }

        public static DateTime ReadDateTime(string prompt)
        {
            DateTime result;
            bool isValidInput;

            do
            {
                Console.Write(prompt);
                isValidInput = DateTime.TryParse(Console.ReadLine(), out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Formato de data inválido. Tente novamente.");
                }

            } while (!isValidInput);

            return result;
        }
    }
}

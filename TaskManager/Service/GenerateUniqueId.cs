using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Service
{
    internal class GenerateUniqueId
    {
        public static int Generate(int lastId)
        {
            return lastId++;
        }
    }
}

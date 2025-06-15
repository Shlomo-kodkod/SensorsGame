using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Program
    {
        internal static void Main()
        {
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                int choice = random.Next(0, 1);
                Console.WriteLine(choice);
            }

        }
    }
}

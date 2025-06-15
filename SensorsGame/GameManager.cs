using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class GameManager
    {
        IranianAgent agent;
        Dictionary<string, int> agentSensors;

        internal int GetIndex(IranianAgent currAgent)
        {
            string strIndex;
            int indexRange = currAgent.GetSensorsCount();

            do
            {
                Console.WriteLine($"Enter the sensor location: ");
                strIndex = Console.ReadLine();
            }
            while ((!int.TryParse(strIndex, out _)) || (int.Parse(strIndex) < 0 || int.Parse(strIndex) >= indexRange));

            return int.Parse(strIndex);
        }



    }
}

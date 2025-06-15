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


        internal GameManager(InitGame initGame)
        {
            this.agent = initGame.InitAgent();
            this.agentSensors = agent.GetAgentSensors();
        }

        internal void UpdateAgentSensors(string type)
        {
            if ((this.agentSensors.ContainsKey(type)) && (this.agentSensors[type] > 0))
            {
                this.agentSensors[type]--;
            }
        }


        internal bool IsValidSensorType(string type)
        {
            string[] validOptions = new string[] { "Audio Sensor" };

            if (validOptions.Contains(type))
            {
                return true;
            }
            Console.WriteLine("Invalid sensor type. please try again.");
            return false;
        }

        internal string GetSensorGuess()
        {
            string guess = "";
            do
            {
                Console.WriteLine("Please enter your guess: ");
                guess = Console.ReadLine();
            }
            while (!IsValidSensorType(guess));

            return guess;
        }


        //internal int GetIndex(IranianAgent currAgent)
        //{
        //    string strIndex;
        //    int indexRange = currAgent.GetSensorsCount();

        //    do
        //    {
        //        Console.WriteLine($"Enter the sensor location: ");
        //        strIndex = Console.ReadLine();
        //    }
        //    while ((!int.TryParse(strIndex, out _)) || (int.Parse(strIndex) < 0 || int.Parse(strIndex) >= indexRange));

        //    return int.Parse(strIndex);
        //}



    }
}

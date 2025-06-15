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
        List<string> correctGuessSensor = new List<string>();


        public GameManager(InitGame initGame)
        {
            this.agent = initGame.InitAgent();
            this.agentSensors = agent.GetAgentSensors();
        }

        public void UpdateAgentSensors(string type)
        {
            if ((this.agentSensors.ContainsKey(type)) && (this.agentSensors[type] > 0))
            {
                this.agentSensors[type]--;
            }
        }


        public bool IsValidSensorType(string type)
        {
            string[] validOptions = new string[] { "Audio Sensor" };

            if (validOptions.Contains(type))
            {
                return true;
            }
            Console.WriteLine("Invalid sensor type. please try again.");
            return false;
        }

        public string GetSensorGuess(IranianAgent agent)
        {
            string guess = "";
            do
            {
                Console.WriteLine($"Sensor options: {agent.GetValidSensorType()}\n" + 
                    "Please enter your guess: "
                    );
                guess = Console.ReadLine();
            }
            while (!IsValidSensorType(guess));

            return guess;
        }

        public string DisplayState(IranianAgent agent)
        {
            return $"{agent.exposedNum}/{agent.GetSensorsCount()}";
        }

        public void GuessSensor(IranianAgent agent, Sensor sensor)
        {
            string guess = GetSensorGuess(agent);
            sensor.Activate();

            if (agent.IsCorrect(guess,this.agentSensors))
            {
                Console.WriteLine("Good guess:)");
                agent.UpdateExposedNum();
                this.correctGuessSensor.Add(guess);
            }
            else
            {
                Console.WriteLine("Wrong guess. Please try again.");
            }
            
        }

    }
}

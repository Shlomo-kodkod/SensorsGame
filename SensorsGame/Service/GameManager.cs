using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame.Service
{
    internal static class GameManager
    {
        public static string ActivateSensors(Agent agent)
        {
            AgentManager.ResetWeaknessAndSensors(agent);
            AgentManager.TryToAttack(agent);
            Dictionary<int, string> brokenSensors = AgentManager.GetBrokenSensors(agent);
            AgentManager.RemoveBrokenSensore(agent, brokenSensors);
            string guess = GetSensorGuess(agent);
            if (guess.Equals("0"))
            {
                return guess;
            }
            Sensor newSensor = SensorFactory.CreateSensor(guess);
            newSensor.Activate(agent);
            agent.UpdateIsSensorExposed(GameLogic.ConvertChoiceTostring(guess));
            AgentManager.UpdateActiveNum(agent);
            agent.turnCount++;
            return guess;
        }

        public static string StartPlay(Agent agent)
        {
            string guess = "";
            string level = "";
            do
            {
                guess = ActivateSensors(agent);
                Console.WriteLine(DisplayState(agent));
                level = agent.rank;
                if (guess == "0")
                {
                    level = "Exit";
                    break;
                }
            }
            while (!agent.IsExposed());
            return level;
        }

        public static string GetSensorGuess(Agent agent)
        {
            string guess = "";
            Sensor newSensor = null;
            do
            {
                Console.WriteLine($"---Sensor options---\n" + $"{GameLogic.GetSensorTypes()}" +
                    "0. Exit.\n" +
                    "Please enter your guess: "
                    );
                guess = Console.ReadLine();
            }
            while (!GameLogic.IsValidSensorType(guess));

            return guess;
        }

        public static string DisplayState(Agent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.GetSensorsCount()}";
        }

    }
}

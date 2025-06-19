using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class GameManager
    {
        //Activating the sensors on the list. erases broken sensors and attacks if possible.
        private static string ActivateSensors(IAgent agent)
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
            ISensor newSensor = SensorFactory.CreateSensor(guess);
            newSensor.Activate(agent);
            agent.UpdateIsSensorExposed(GameLogic.ConvertChoiceTostring(guess));
            AgentManager.UpdateActiveNum(agent);
            agent.turnCount++;
            return guess;
        }

        //Activating agent's investigation.
        public static string StartPlay(IAgent agent)
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

        //Returns the user guess.
        private static string GetSensorGuess(IAgent agent)
        {
            string guess = "";
            ISensor newSensor = null;
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

        //Shows the number of weaknesses that have been exposed.
        private static string DisplayState(IAgent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.sensorSlots}";
        }

    }
}

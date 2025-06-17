using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame.Service
{
    internal class GameUI
    {
        public static string GetSensorGuess(IranianAgent agent)
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

        public static string DisplayState(IranianAgent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.GetSensorsCount()}";
        }   
        
    }
}

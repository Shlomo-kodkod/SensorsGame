using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame.Service
{
    internal static class GameManager
    {
        public static string ActivateSensors(IranianAgent agent)
        {
            AgentManager.ResetWeaknessAndSensors(agent);
            AgentManager.TryToAttack(agent);
            Dictionary<int, string> brokenSensors = GameLogic.GetBrokenSensors(agent);
            GameLogic.RemoveBrokenSensore(agent, brokenSensors);
            string guess = GameUI.GetSensorGuess(agent);
            if (guess.Equals("0"))
            {
                return guess;
            }
            Sensor newSensor = SensorFactory.CreateSensor(guess);
            newSensor.Activate(agent);
            agent.UpdateIsSensorExposed(GameLogic.ConvertChoiceTostring(guess));
            GameLogic.UpdateActiveNum(agent);
            agent.turnCount++;
            return guess;
        }

        public static string StartPlay(IranianAgent agent)
        {
            string guess = "";
            string level = "";
            do
            {
                guess = ActivateSensors(agent);
                Console.WriteLine(GameUI.DisplayState(agent));
                level = agent.rank;
                if (guess == "0")
                {
                    Console.WriteLine("Exit...");
                    level = "Exit";
                    break;
                }
            }
            while (!agent.IsExposed());
            return level;
        }

    }
}

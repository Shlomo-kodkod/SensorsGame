using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class GameLogic
    {
        private static string[] validChoice = new string[] { "1", "2", "3", "4", "5", "6", "7", "0" };

        private static string[] validSensorsTypes = new string[] { "Audio Sensor", "Thermal Sensor",
            "Pulse Sensor", "Motion Sensor", "Magnetic",
            "Signal Sensor", "Light Sensor"
            };

        public static void UpdateActiveNum(IranianAgent agent)
        {
            foreach (Sensor sensor in agent.guessedSensors)
            {
                sensor.activationSum++;
            }
        }

        public static bool IsValidSensorType(string type)
        {
            if (validChoice.Contains(type))
            {
                return true;
            }
            Console.WriteLine("Invalid sensor type. please try again.");
            return false;
        }

        public static string ConvertChoiceTostring(string type)
        {
            string newSensor = " ";
            switch (type)
            {
                case "0":
                    newSensor = "Exit";
                    break;
                case "1":
                    newSensor = "Audio Sensor";
                    break;
                case "2":
                    newSensor = "Thermal Sensor";
                    break;
                case "3":
                    newSensor = "Pulse Sensor";
                    break;
                case "4":
                    newSensor = "Motion Sensor";
                    break;
                case "5":
                    newSensor = "Magnetic";
                    break;
                case "6":
                    newSensor = "Signal Sensor";
                    break;
                case "7":
                    newSensor = "Light Sensor";
                    break;
            }
            return newSensor;
        }

        public static string GetSensorTypes()
        {
            string sensortypeOptions = "";

            for (int i = 0; i < validChoice.Length - 1; i++)
            {
                sensortypeOptions += $"{i + 1}. {validSensorsTypes[i]}.\n";
            }
            return sensortypeOptions;
        }

        public static Dictionary<int, string> GetBrokenSensors(IranianAgent agent)
        {
            string[] breakableSensors = new string[] { "Pulse Sensor", "Motion Sensor" };
            Dictionary<int, string> sensorsMap = new Dictionary<int, string>();

            for (int i = 0; i < agent.guessedSensors.Count(); i++)
            {
                if (breakableSensors.Contains(agent.guessedSensors[i].type) &&
                    (agent.guessedSensors[i].activationSum > 3))
                {
                    sensorsMap[i] = agent.guessedSensors[i].type;
                }
            }
            return sensorsMap;
        }

        public static void RemoveBrokenSensore(IranianAgent agent, Dictionary<int, string> sensorsMap)
        {
            if ((agent.guessedSensors.Count() > 0) && (sensorsMap.Count > 0))
            {
                foreach (KeyValuePair<int, string> item in sensorsMap)
                {
                    Console.WriteLine($"Sensor is broken. Sensor type: {agent.guessedSensors[item.Key].type}");
                    agent.UpdateIsSensorExposed(item.Value);
                    agent.RemoveSensor(item.Key);
                    agent.SubExposedNum();
                }
            }
        }

    }
}

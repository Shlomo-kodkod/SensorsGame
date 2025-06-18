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


        //hecking if the sensor name is validate.
        public static bool IsValidSensorType(string type)
        {
            if (validChoice.Contains(type))
            {
                return true;
            }
            Console.WriteLine("Invalid sensor type. please try again.");
            return false;
        }

        //Converts the number that the user has entered
        //into the name of a matching sensor.
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

        //Returns the type of sensor.
        public static string GetSensorTypes()
        {
            string sensortypeOptions = "";

            for (int i = 0; i < validChoice.Length - 1; i++)
            {
                sensortypeOptions += $"{i + 1}. {validSensorsTypes[i]}.\n";
            }
            return sensortypeOptions;
        }



    }
}

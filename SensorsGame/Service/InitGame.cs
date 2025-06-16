using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class InitGame
    {
        private static Random random= new Random();
        private static string[] sensorOption = new string[] { "Audio Sensor" };

        public static string[] InitSensors(int sensorSlots)
        {
            string[] sensorsOptions = new string[sensorSlots];

            for (int i = 0; i <= sensorSlots; i++)
            {
                int choice = random.Next(0, sensorOption.Length);
                switch (choice)
                {
                    case 0:
                        sensorsOptions.Append("Audio Sensor");
                        break;    
                }
            }
            return sensorsOptions;
        }

        public static IranianAgent InitAgent(string agentType = "")
        {
            IranianAgent result = null;
            switch (agentType)
            {
                case "Foot Soldier":
                    result = new FootSoldier(InitSensors(2));
                    break;
                default:
                    result = new FootSoldier(InitSensors(2));
                    break;
            }
            return result;
        }


    }
}

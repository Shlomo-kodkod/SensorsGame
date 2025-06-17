using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame.Service
{
    internal static class AgentFactory
    {
        private static Random random = new Random();
        private static string[] sensorOption = new string[] {
            "Audio Sensor", "Thermal Sensor",
            "Pulse Sensor", "Motion Sensor", "Magnetic",
            "Signal Sensor", "Light Sensor"
        };

        public static string[] InitializeSensorsRandom(int sensorSlots)
        {
            string[] sensorsOptions = new string[sensorSlots];

            for (int i = 0; i < sensorSlots; i++)
            {
                int choice = random.Next(0, sensorOption.Length);
                switch (choice)
                {
                    case 0:
                        sensorsOptions[i] = sensorOption[0];
                        break;
                    case 1:
                        sensorsOptions[i] = sensorOption[1];
                        break;
                    case 2:
                        sensorsOptions[i] = sensorOption[2];
                        break;
                    case 3:
                        sensorsOptions[i] = sensorOption[3];
                        break;
                    case 4:
                        sensorsOptions[i] = sensorOption[4];
                        break;
                    case 5:
                        sensorsOptions[i] = sensorOption[5];
                        break;
                    case 6:
                        sensorsOptions[i] = sensorOption[6];
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
                    result = new FootSoldier(InitializeSensorsRandom(2));
                    break;
                case "Squad Leader":
                    result = new SquadLeader(InitializeSensorsRandom(4));
                    break;
                case "Senior Commander":
                    result = new SeniorCommander(InitializeSensorsRandom(6));
                    break;
                case "Organization Leader":
                    result = new OrganizationLeader(InitializeSensorsRandom(8));
                    break;

                default:
                    result = new FootSoldier(InitializeSensorsRandom(2));
                    break;
            }
            return result;
        }

    }
}

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
        private static string[] sensorOption = new string[] {
            "Audio Sensor", "Thermal Sensor",
            "Pulse Sensor", "Motion Sensor", "Magnetic",
            "Signal Sensor", "Light Sensor"
        };

        public static string[] InitSensorsRandom(int sensorSlots)
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
        public static Sensor CreatSensor(string type)
        {
            Sensor newSensor = null;
            switch (type)
            {
                case "1":
                    newSensor = new AudioSensor();
                    break;
                case "2":
                    newSensor = new ThermalSensor();
                    break;
                case "3":
                    newSensor = new PulseSensor();
                    break;
                case "4":
                    newSensor = new MotionSensor();
                    break;
                case "5":
                    newSensor = new Magnetic();
                    break;
                case "6":
                    newSensor = new SignalSensor();
                    break;
                case "7":
                    newSensor = new LightSensor();
                    break;
            }
            return newSensor;
        }
        public static IranianAgent InitAgent(string agentType = "")
        {
            IranianAgent result = null;
            switch (agentType)
            {
                case "Foot Soldier":
                    result = new FootSoldier(InitSensorsRandom(2));
                    break;
                case "Squad Leader":
                    result = new SquadLeader(InitSensorsRandom(4));
                    break;
                case "Senior Commander":
                    result = new SeniorCommander(InitSensorsRandom(6));
                    break;
                case "Organization Leader":
                    result = new OrganizationLeader(InitSensorsRandom(8));
                    break;

                default:
                    result = new FootSoldier(InitSensorsRandom(2));
                    break;
            }
            return result;
        }


    }
}

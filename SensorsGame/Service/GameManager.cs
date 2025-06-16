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
        Sensor sensor = new Sensor();
        string[] validSensorsTypes = new string[] { "Audio Sensor", "Thermal Sensor",
            "Pulse Sensor", "Motion Sensor", "Magnetic",
            "Signal Sensor", "Light Sensor"
            };
        string[] validChoice = new string[] { "1", "2", "3", "4", "5", "6", "7" };


        public GameManager()
        {
            this.agent = InitGame.InitAgent();
        }

        public bool IsValidSensorType(string type)
        {
            if (this.validChoice.Contains(type))
            {
                return true;
            }
            Console.WriteLine("Invalid sensor type. please try again.");
            return false;
        }
        public string GetSensorTypes()
        {
            string sensortypeOptions = "";

            for (int i = 0;i < this.validChoice.Length; i++)
            {
                sensortypeOptions += $"{i+1}. {this.validSensorsTypes[i]}.\n";
            }
            return sensortypeOptions;
        }

        public string ConvertChoiceTostring(string type)
        {
            string newSensor = " ";
            switch (type)
            {
                case "1":
                    newSensor = "Audio Sensor";
                    break;
                case "2":
                    newSensor = "Thermal Sensor";
                    break;
                case "3":
                    newSensor =  "Pulse Sensor";
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
                    newSensor = "LightSensor";
                    break;
            }
            return newSensor;
        }
        public string GetSensorGuess(IranianAgent agent)
        {
            string guess = "";
            Sensor newSensor = null;
            do
            {
                Console.WriteLine($"---Sensor options---\n" + $"{GetSensorTypes()}\n" + 
                    "Please enter your guess: "
                    );
                guess = Console.ReadLine();
            }
            while (!IsValidSensorType(guess));

            return guess;
        }

        public string DisplayState(IranianAgent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.GetSensorsCount()}";
        }   

        public void GuessSensor(IranianAgent agent)
        {
            string guess = GetSensorGuess(agent);
            Sensor newSensor = InitGame.CreatSensor(guess);
            newSensor.Activate(agent);
            agent.UpdateIsSensorExposed(ConvertChoiceTostring(guess));
            UpdateActiveNum(agent);
            agent.turnNum++;
            //RemoveBreakableSensore(agent);
        }
        public void StartPlay()
        {
            do
            {
                GuessSensor(agent);
                Console.WriteLine(DisplayState(agent));
            }
            while (!agent.IsExposed());
            Console.WriteLine("Good Game. Bey bey.");
        }   
        public void UpdateActiveNum(IranianAgent agent)
        {
            foreach(Sensor sensor in agent.guessSensors)
            {
                sensor.activeateSum++;
            }
        }
        public string RemoveBreakableSensore(IranianAgent agent)
        {
            string[] breakableSensors = new string[] { "Pulse Sensor", "Motion Sensor" };
            string senType = "";

            for(int i = agent.guessSensors.Count() - 1; i >= 0 ;i--)
            {
                if (breakableSensors.Contains(agent.guessSensors[i].type))
                {
                    if (agent.guessSensors[i].activeateSum >= 3)
                    {
                        senType = agent.guessSensors[i].type;
                        Console.WriteLine($"Sensor {agent.guessSensors[i].type} break.");
                        agent.UpdateIsSensorExposed(agent.guessSensors[i].type);
                        agent.RemoveSensor(i);
                        agent.SubExposedNum();
                        
                    }
                    
                }
            }
            return senType;
        }

    }
}

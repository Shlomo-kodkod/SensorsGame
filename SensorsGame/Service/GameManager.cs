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

        public Sensor ConvertStringToSensor(string type)
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
        public Sensor GetSensorGuess(IranianAgent agent)
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

            return InitGame.CreatSensor(guess);
        }

        public string DisplayState(IranianAgent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.GetSensorsCount()}";
        }   

        public void GuessSensor(IranianAgent agent)
        {
            Sensor guess = GetSensorGuess(agent);
            guess.Activate(agent);
            UpdateActiveNum(agent);
            RemoveBreakableSensore(agent);
            agent.turnNum++;
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
        public void RemoveBreakableSensore(IranianAgent agent)
        {
            string[] breakableSensors = new string[] { "Pulse Sensor", "Motion Sensor" };

            for(int i = agent.guessSensors.Count() - 1; i >= 0 ;i--)
            {
                if (breakableSensors.Contains(agent.guessSensors[i].type) && (agent.guessSensors[i].activeateSum == 3))
                {
                    Console.WriteLine($"Sensor {agent.guessSensors[i].type} break.");
                    agent.RemoveSensor(i);
                }
            }
            
        }

    }
}

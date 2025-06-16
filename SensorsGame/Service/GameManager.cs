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
            "Pulse Sensor", "Motion Sensor", "Magnetic" };
        string[] validChoice = new string[] { "1", "2", "3", "4", "5" };


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
            }
            return newSensor;
        }
        public Sensor GetSensorGuess(IranianAgent agent)
        {
            string guess = "";
            Sensor newSensor = null;
            do
            {
                Console.WriteLine($"---Sensor options---\n {GetSensorTypes()}\n" + 
                    "Please enter your guess: "
                    );
                guess = Console.ReadLine();
            }
            while (!IsValidSensorType(guess));

            return ConvertStringToSensor(guess);
        }

        public string DisplayState(IranianAgent agent)
        {
            return $"Your match is: {agent.exposedNum}/{agent.GetSensorsCount()}";
        }   

        public void GuessSensor(IranianAgent agent)
        {
            Sensor guess = GetSensorGuess(agent);
            sensor.Activate(agent,guess); 
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
    }
}

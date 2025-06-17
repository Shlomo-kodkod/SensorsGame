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
        Random random = new Random();

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
        public void ActivateSensors(IranianAgent agent)
        {
            TryToAttack(agent);
            Dictionary<int, string> brokenSensors = GetBrokenSensors(agent);
            RemoveBrokenSensore(agent, brokenSensors);
            string guess = GetSensorGuess(agent);
            Sensor newSensor = InitGame.CreatSensor(guess);
            newSensor.Activate(agent);
            agent.UpdateIsSensorExposed(ConvertChoiceTostring(guess));
            UpdateActiveNum(agent);
            agent.turnNum++;
            
        }
        public void StartPlay()
        {
            do
            {
                ActivateSensors(agent);
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
        public bool IsAbleToCancelsAttack(IranianAgent agent)
        {
            foreach (Sensor sensor in agent.guessSensors)
            {
                if ((sensor.isCancelsCounterAttack) && (sensor.cancelsAttackSum < 2))
                {
                    return true;
                }
            }
            return false;
        }
        public void TryToAttack(IranianAgent agent)
        {
            if((agent.IsAttack) && (agent.attackNum > 0) &&
                (!IsAbleToCancelsAttack(agent)) && (agent.turnNum != 0) && 
                (agent.turnNum % 3 == 0) && (agent.guessSensors.Count() > 0))
            {
                int range = agent.guessSensors.Count();
                int index = random.Next(0, range);
                agent.RemoveSensor(index);
                Console.WriteLine("Agent committed an attack. One sensor was erased.");
                UpdateCancelsAttack(agent);
                agent.SubExposedNum();
                agent.attackNum--;

            }
        }
        public void UpdateCancelsAttack(IranianAgent agent)
        {
            foreach(Sensor sensor in agent.guessSensors)
            {
                if ((sensor.isCancelsCounterAttack) && (sensor.cancelsAttackSum < 2))
                {
                    sensor.cancelsAttackSum++;
                    break;
                }
            }
        }
        public Dictionary<int, string> GetBrokenSensors(IranianAgent agent)
        {
            string[] breakableSensors = new string[] { "Pulse Sensor", "Motion Sensor" };
            Dictionary<int, string> sensorsMap = new Dictionary<int, string>();

            for (int i = 0; i < agent.guessSensors.Count(); i++)
            {
                if (breakableSensors.Contains(agent.guessSensors[i].type) && 
                    (agent.guessSensors[i].activeateSum > 3))
                {
                    sensorsMap[i] = agent.guessSensors[i].type;
                }
            }
            return sensorsMap;
        }
        public void RemoveBrokenSensore(IranianAgent agent, Dictionary<int, string> sensorsMap)
        {
            if ((agent.guessSensors.Count() > 0) && (sensorsMap.Count > 0))
            {
                foreach(KeyValuePair<int , string> item in sensorsMap)
                {
                    Console.WriteLine($"Sensor break. Sensor type: {agent.guessSensors[item.Key].type}");
                    agent.UpdateIsSensorExposed(item.Value);
                    agent.RemoveSensor(item.Key);
                    agent.SubExposedNum();
                }
            }
        }

    }
}

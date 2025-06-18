using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsGame.Service;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace SensorsGame
{
    internal class AgentManager
    {
        private static Random random = new Random();

        public static void TryToAttack(Agent agent)
        {
            if ((agent.IsAttack) && (agent.attackNum > 0) &&
                (!IsAbleToCancelsAttack(agent)) && (agent.turnCount != 0) &&
                (agent.turnCount % 3 == 0) && (agent.guessedSensors.Count() > 0))
            {
                int range = agent.guessedSensors.Count();
                int index = random.Next(0, range);
                agent.RemoveSensor(index);
                Console.WriteLine("Agent committed an attack. One sensor was erased.");
                UpdateCancelsAttack(agent);
                agent.SubExposedNum();
                agent.attackNum--;

            }
        }

        public static void UpdateCancelsAttack(Agent agent)
        {
            foreach (Sensor sensor in agent.guessedSensors)
            {
                if ((sensor.isCancelsCounterAttack) && (sensor.cancelsAttackSum < 2))
                {
                    sensor.cancelsAttackSum++;
                    break;
                }
            }
        }

        public static bool IsAbleToCancelsAttack(Agent agent)
        {
            foreach (Sensor sensor in agent.guessedSensors)
            {
                if ((sensor.isCancelsCounterAttack) && (sensor.cancelsAttackSum < 2))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ResetWeaknessAndSensors(Agent agent)
        {
            if ((agent.rank == "Organization Leader") && (agent.turnCount != 0) &&
                (agent.turnCount % 10 == 0))
            {
                Console.WriteLine("Too many game attempts. Game reset.");
                agent.sensors = AgentFactory.InitializeSensorsRandom(8);
                agent.guessedSensors.Clear();
                agent.exposedNum = 0;
                for (int i = 0; i < agent.isSensorExposed.Length; i++)
                {
                    agent.isSensorExposed[i] = false;
                }
            }
        }

        public static void UpdateActiveNum(Agent agent)
        {
            foreach (Sensor sensor in agent.guessedSensors)
            {
                sensor.activationSum++;
            }
        }

        public static Dictionary<int, string> GetBrokenSensors(Agent agent)
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

        public static void RemoveBrokenSensore(Agent agent, Dictionary<int, string> sensorsMap)
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

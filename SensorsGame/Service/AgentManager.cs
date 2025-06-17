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

        public static void TryToAttack(IranianAgent agent)
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

        public static void UpdateCancelsAttack(IranianAgent agent)
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

        public static bool IsAbleToCancelsAttack(IranianAgent agent)
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

        public static void ResetWeaknessAndSensors(IranianAgent agent)
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


    }
}

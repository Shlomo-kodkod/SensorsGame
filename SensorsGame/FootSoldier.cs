using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class FootSoldier : IranianAgent
    {
        Sensor[] sensors;
        string rank = "Foot Soldier";
        int sensorSlots = 2;
        int exposedNum;


        internal FootSoldier(Sensor[] Sensors)
        {
            this.sensors = Sensors;

        }
        internal override int GetSensorsCount()
        {
            return this.sensorSlots;
        }

        

        internal override Dictionary<string, int> GetAgentSensors()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach(Sensor sensor in this.sensors)
            {
                if (result.ContainsKey(sensor.GetType()))
                {
                    result[sensor.GetType()]++; 
                }
                else
                {
                    result[sensor.GetType()] = 1;
                }
            }

            return result;
        }

        internal override bool IsCorrect(string type, Dictionary<string, int> agentSensor)
        {
            if (agentSensor.ContainsKey(type) && agentSensor[type] > 0)
            {
                return true;
            }
            return false;
        }

        internal override bool IsExposed()
        {
            return this.exposedNum == this.sensorSlots;
        }

        internal override void UpdateExposedNum()
        {
            this.exposedNum++;
        }

    }
}

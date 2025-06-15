using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class IranianAgent : IIranianAgent
    {
        public Sensor[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }


        public IranianAgent(Sensor[] Sensors)
        {
            this.sensors = Sensors;

        }
        public int GetSensorsCount()
        {
            return this.sensorSlots;
        }



        public Dictionary<string, int> GetAgentSensors()
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

        public bool IsCorrect(string type, Dictionary<string, int> agentSensor)
        {
            if (agentSensor.ContainsKey(type) && agentSensor[type] > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsExposed()
        {
            return this.exposedNum == this.sensorSlots;
        }

        public void UpdateExposedNum()
        {
            this.exposedNum++;
        }

        public string GetValidSensorType()
        {
            string sensortypeOptions = "";

            foreach(Sensor sensor in this.sensors)
            {
               sensortypeOptions += sensor.GetType() + " ";
            }
            return sensortypeOptions;
        }


    }
}

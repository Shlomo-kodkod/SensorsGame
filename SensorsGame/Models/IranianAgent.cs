using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class IranianAgent : IIranianAgent
    {

        public string[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }

        private List<Sensor> guessSensors = new List<Sensor>();

        public IranianAgent(string[] Sensors)
        {
            this.sensors = Sensors;
        }
        public int GetSensorsCount()
        {
            return this.sensorSlots;
        }

        //public List<string> GetAgentSensors()
        //{
        //    List<string> agentSensors = new List<string>();

        //    foreach(string sensor in this.sensors)
        //    {
        //        agentSensors.Add(sensor);
        //    }
        //    return agentSensors;
        //}

        public int GetSpecificCount(string type)
        {
            int count = 0;
            foreach(Sensor sensor in this.guessSensors)
            {
                if (sensor.type == type)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsCorrect(string type)
        {
            if (this.sensors.Contains(type))
            {
                if ((GetSpecificCount(type) == 0) || (GetSpecificCount(type) < this.sensors.Count(cnt => cnt == type)))
                {
                    return true;
                }
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

        public void RemoveSensor(string seneorType)
        {
            foreach(Sensor sensor in this.guessSensors)
            {
                if (sensor.type == seneorType)
                {
                    this.guessSensors.Remove(sensor);
                }
            }
        }

        public void AddSensore(Sensor sensor)
        {
            this.guessSensors.Add(sensor);
        }
    }
}

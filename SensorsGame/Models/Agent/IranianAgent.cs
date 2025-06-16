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

        public bool IsAttack = false;

        public int attackNum;

        public int turnNum = 0;

        public List<Sensor> guessSensors = new List<Sensor>();

        public bool[] isSensorExposed;

        public IranianAgent(string[] Sensors)
        {
            this.sensors = Sensors;
            this.isSensorExposed = new bool[sensors.Length];
            for(int i = 0; i < sensors.Length; i++)
            {
                this.isSensorExposed[i] = false;
            }
        }
        public int GetSensorsCount()
        {
            return this.sensorSlots;
        }

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
            for (int i = 0; i < sensors.Length; i++)
            {
                if ((sensors[i] == type) && (!isSensorExposed[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateIsSensorExposed(string type)
        {
            for (int i = 0; i < this.sensors.Length; i++)
            {
                if (this.sensors[i] == type && this.isSensorExposed[i])
                {
                    this.isSensorExposed[i] = false;
                    break;
                }
                else if ((this.sensors[i] == type) && (!this.isSensorExposed[i]))
                {
                    this.isSensorExposed[i] = true;
                    break;
                }
            }
        }

        public bool IsExposed()
        {
            return this.exposedNum == this.sensorSlots;
        }

        public void AddExposedNum()
        {
            ++this.exposedNum;
        }

        public void SubExposedNum()
        {
            --this.exposedNum;
        }

        public void RemoveSensor(int index)
        {
           this.guessSensors.RemoveAt(index);
        }

        public void AddSensore(Sensor sensor)
        {
            this.guessSensors.Add(sensor);
        }
    }
}

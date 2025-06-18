using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Agent : IAgent
    {

        public string[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }

        public bool IsAttack = false;

        public int turnCount = 0;

        public int attackNum;

        public List<Sensor> guessedSensors = new List<Sensor>();

        public bool[] isSensorExposed;

        public Agent(string[] Sensors)
        {
            this.sensors = Sensors;
            this.isSensorExposed = new bool[sensors.Length];
            for(int i = 0; i < sensors.Length; i++)
            {
                this.isSensorExposed[i] = false;
            }
        }

        //Check if the agent has this weakness.
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

        //Updates the status of the exposed weakness in the list of weaknesses.
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

        //Check  if all the weaknesses have been identified.
        public bool IsExposed()
        {
            return this.exposedNum == this.sensorSlots;
        }

        //Update the number of weaknesses exposed.
        public void AddExposedNum()
        {
            ++this.exposedNum;
        }

        //Update the number of weaknesses exposed.
        public void SubExposedNum()
        {
            --this.exposedNum;
        }

        //Deletes a sensor from the sensors attached to the agent.
        public void RemoveSensor(int index)
        {
            if (this.guessedSensors.Count() > index)
            {
                this.guessedSensors.RemoveAt(index);
            }
        }

        //Attach a new sensor to the agent
        public void AttachingNewSensor(Sensor sensor)
        {
            this.guessedSensors.Add(sensor);
        }

    }
}

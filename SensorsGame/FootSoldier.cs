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

        internal override Sensor[] GetAgentSensors()
        {
            return this.sensors;
        }

        internal override bool IsCorrect(string type, int index)
        {
            if ((index >= 0) && (index < this.GetSensorsCount()))
            {
               string  currType = this.sensors[index].GetType();
                return  currType == type;
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

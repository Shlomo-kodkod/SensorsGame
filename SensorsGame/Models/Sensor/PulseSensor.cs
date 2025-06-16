using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class PulseSensor : Sensor
    {
        private bool IsBroken = false;
        public PulseSensor()
        {
            this.type = "Pulse Sensor";
        }

        public override void Activate(IranianAgent agent, Sensor sensor)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.AddSensore(sensor);
                agent.UpdateExposedNum();
            }
        }

        public bool GetStatus()
        {
            return this.IsBroken;
        }
        public void ChangeStatus()
        {
            this.IsBroken = true;
        }
    }
}

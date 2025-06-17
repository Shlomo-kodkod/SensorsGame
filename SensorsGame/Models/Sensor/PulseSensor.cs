using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class PulseSensor : Sensor
    {
        public PulseSensor()
        {
            this.type = "Pulse Sensor";
        }

        public override void Activate(IranianAgent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.DecrementExposedNum(this);
                agent.AddExposedNum();
            }
        }

    }
}

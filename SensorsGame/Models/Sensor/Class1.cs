using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class MotionSensor : Sensor
    {
        public MotionSensor()
        {
            this.type = "Motion Sensor";
        }

        public override void Activate(IranianAgent agent, Sensor sensor)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.AddSensore(sensor);
                agent.UpdateExposedNum();
            }
        }
    }
}

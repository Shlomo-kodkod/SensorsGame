using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class MotionSensor : PulseSensor
    {
        public MotionSensor()
        {
            this.type = "Motion Sensor";
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class AudioSensor : Sensor 
    {
        string type = "Audio Sensor";
        internal override string Activate()
        {
            return $"{this.type} is active.";
        }

        internal override string GetType()
        {
            return this.type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Sensor : ISensor
    {
        string type { get; set; }
        internal string Activate()
        {
            return $"{this.type} is active.";
        }

        internal string GetType()
        {
            return this.type;
        }
    }
}

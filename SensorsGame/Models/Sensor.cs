using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Sensor : ISensor
    {
        public string type { get; set; }
        public string Activate()
        {
            return $"{this.type} is active.";
        }

        public string GetType()
        {
            return this.type;
        }
    }
}

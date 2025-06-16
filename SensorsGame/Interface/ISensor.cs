using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface ISensor
    {
        public string type { get; set; }

        public void Activate(IranianAgent agent, Sensor sensor);

        public string GetType();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal abstract class Sensor
    {
        string type;

        internal abstract string Activate();
    }
}

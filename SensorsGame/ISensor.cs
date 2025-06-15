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

        public string Activate();

        public string GetType();
    }
}

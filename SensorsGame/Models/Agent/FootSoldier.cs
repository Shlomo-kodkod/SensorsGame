using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class FootSoldier : Agent
    {
        public FootSoldier(string[] sensor) : base(sensor)
        {
            this.rank = "Foot Soldier";
            this.sensorSlots = 2;
        }
    }
}

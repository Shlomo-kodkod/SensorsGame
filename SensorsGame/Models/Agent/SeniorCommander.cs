using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class SeniorCommander : Agent
    {
        public SeniorCommander(string[] sensor) : base(sensor)
        {
            this.rank = "Senior Commander";
            this.sensorSlots = 6;
            this.IsAttack = true;
            this.attackNum = 2;
        }
    }
}

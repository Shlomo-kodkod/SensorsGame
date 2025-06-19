using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Magnetic : Sensor
    {
        public Magnetic()
        {
            this.type = "Magnetic";
            this.isCancelsCounterAttack = true;
            this.cancelsAttackSum = 0;
        }

    }
}

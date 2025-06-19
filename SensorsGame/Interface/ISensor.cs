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

        public int activationSum { get; set; }

        public bool isCancelsCounterAttack { get; set; }

        public int cancelsAttackSum { get; set; }

        public bool IsBroken { get; set; }

        public void Activate(IAgent agent);

    }
}

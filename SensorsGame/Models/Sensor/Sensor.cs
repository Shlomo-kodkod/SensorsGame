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

        public int activationSum = 0;

        public bool isCancelsCounterAttack = false;
        public int cancelsAttackSum { get; set; }

        public bool IsBroken = false;

        public virtual void Activate(IranianAgent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.DecrementExposedNum(this);
                agent.AddExposedNum();
            }
        }

        
    }
}

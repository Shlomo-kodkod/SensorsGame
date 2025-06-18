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

        //Activates the sensor and attaches it to the agent if it is on the list of weaknesses.
        public virtual void Activate(Agent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.AttachingNewSensor(this);
                agent.AddExposedNum();
            }
        }

    }
}

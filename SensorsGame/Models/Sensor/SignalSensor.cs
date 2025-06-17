using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class SignalSensor : Sensor
    {
        public SignalSensor()
        {
            this.type = "Signal Sensor";
        }

        public override void Activate(IranianAgent agent)
        {


            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine($"You've uncovered information about the agent. Agent rank is: {agent.rank}");
                agent.DecrementExposedNum(this);
                agent.AddExposedNum();
            }
        }
    }
}

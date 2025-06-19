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

        //Activates the sensor and attaches it to the agent if he is on the list of weaknesses
        //and reveals details about the agent.
        public override void Activate(IAgent agent)
        {


            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine($"You've uncovered information about the agent. Agent rank is: {agent.rank}");
                agent.AttachingNewSensor(this);
                agent.AddExposedNum();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class LightSensor : Sensor
    {
        public LightSensor()
        {
            this.type = "Light Sensor";
        }

        //Activates the sensor and attaches it to the agent if he is on the list of weaknesses
        //and reveals details about the agent.
        public override void Activate(IAgent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine("You've uncovered information about the agent.\n" + 
                    $"Agent rank is: {agent.rank}\n" +
                    $"Agent Sensor slots is: {agent.sensorSlots}"
                    );
                agent.AttachingNewSensor(this);
                agent.AddExposedNum();
            }
        }
    }
}

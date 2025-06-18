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
        public override void Activate(Agent agent)
        {

            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine("You've uncovered information about the agent.\n" + 
                    $"Agent rank is: {agent.rank}\n" +
                    $"Agent Sensor slots is: {agent.sensorSlots}"
                    );
                agent.DecrementExposedNum(this);
                agent.AddExposedNum();
            }
        }
    }
}

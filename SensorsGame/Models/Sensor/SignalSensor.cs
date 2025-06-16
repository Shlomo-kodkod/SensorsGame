using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class SignalSensor : Sensor
    {
        public override void Activate(IranianAgent agent, Sensor sensor)
        {

            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine($"You've uncovered information about the agent. Agent rank is: {agent.rank}");
                agent.AddSensore(sensor);
                agent.UpdateExposedNum();
            }
        }
    }
}

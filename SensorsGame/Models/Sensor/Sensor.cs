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
        public virtual void Activate(IranianAgent agent, Sensor sensor)
        {
            if (agent.IsCorrect(this.type))
            {
                agent.AddSensore(sensor);
                agent.UpdateExposedNum();
            }
        }

        public string GetType()
        {
            return this.type;
        }
    }
}

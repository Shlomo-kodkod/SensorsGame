using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class ThermalSensor : Sensor
    {
        private Random random = new Random();
        public ThermalSensor()
        {
            this.type = "Thermal Sensor";
        }


        //Activates the sensor and attaches it to the agent if it is on the list of weaknesses
        //and reveals the name of a sensor from the list of weaknesses
        public override void Activate(Agent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine($"You exposed a sensor from the secret list. Sensor name: {RevealsOneSensore(agent)}");
                agent.AttachingNewSensor(this);
                agent.AddExposedNum();
            }
        }

        //Reveals the name of a sensor from the list of weaknesses.
        public string RevealsOneSensore(Agent agent)
        {
            int weaknessLength = agent.sensorSlots;
            int randomIndex = random.Next(0, weaknessLength);

            return agent.sensors[randomIndex];
        }
    }
}

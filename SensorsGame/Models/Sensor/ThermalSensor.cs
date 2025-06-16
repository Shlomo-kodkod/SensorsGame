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

        public override void Activate(IranianAgent agent)
        {
            if (agent.IsCorrect(this.type))
            {
                Console.WriteLine($"You exposed a sensor from the secret list. Sensor name: {RevealsOneSensore(agent)}");
                agent.AddSensore(this);
                agent.AddExposedNum();
            }
        }

        public string RevealsOneSensore(IranianAgent agent)
        {
            int weaknessLength = agent.GetSensorsCount();
            int randomIndex = random.Next(0, weaknessLength);

            return agent.sensors[randomIndex];
        }
    }
}

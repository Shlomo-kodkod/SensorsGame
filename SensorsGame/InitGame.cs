using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class InitGame
    {
        Random random= new Random();
       

        internal Sensor[] InitSensors(int sensorSlots)
        {
            Sensor[] sensorsOptions = new Sensor[sensorSlots];

            for (int i = 0; i <= sensorSlots; i++)
            {
                int choice = random.Next(0, 1);
                switch (choice)
                {
                    case 0:
                        sensorsOptions.Append(new AudioSensor());
                        break;
                    
                }
            }

            return sensorsOptions;
        }

        internal IranianAgent InitAgent()
        {
            IranianAgent result = null;
            int choice = random.Next(0, 1);
            switch (choice)
            {
                case 0:
                    result = new FootSoldier(InitSensors(2));
                    break;

            }

            return result;
        }


    }
}

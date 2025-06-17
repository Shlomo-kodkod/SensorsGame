using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class SensorFactory
    {
        public static Sensor CreateSensor(string type)
        {
            Sensor newSensor = null;
            switch (type)
            {
                case "1":
                    newSensor = new AudioSensor();
                    break;
                case "2":
                    newSensor = new ThermalSensor();
                    break;
                case "3":
                    newSensor = new PulseSensor();
                    break;
                case "4":
                    newSensor = new MotionSensor();
                    break;
                case "5":
                    newSensor = new Magnetic();
                    break;
                case "6":
                    newSensor = new SignalSensor();
                    break;
                case "7":
                    newSensor = new LightSensor();
                    break;
            }
            return newSensor;
        }

    }
}

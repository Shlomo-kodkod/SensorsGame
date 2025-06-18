using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface IAgent
    {
        public string[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }

        public bool IsCorrect(string type);
        public bool IsExposed();
        public void AddExposedNum();
        public void SubExposedNum();
        public void RemoveSensor(int index);
        public void AttachingNewSensor(Sensor sensor);




    }
}

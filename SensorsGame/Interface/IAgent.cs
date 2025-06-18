using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface IAgent
    {
        public bool IsCorrect(string type);
        public void UpdateIsSensorExposed(string type);
        public bool IsExposed();
        public void AddExposedNum();
        public void SubExposedNum();
        public void RemoveSensor(int index);
        public void AttachingNewSensor(Sensor sensor);




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface IIranianAgent
    {
        public string[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }

        public int GetSensorsCount();
        public bool IsCorrect(string type);
        public bool IsExposed();
        public void UpdateExposedNum();
        public void RemoveSensor(int index);
        public void AddSensore(Sensor sensor);




    }
}

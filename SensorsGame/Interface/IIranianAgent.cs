using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface IIranianAgent
    {
        public Sensor[] sensors { get; set; }
        public string rank { get; set; }
        public int sensorSlots { get; set; }
        public int exposedNum { get; set; }

        public int GetSensorsCount();
        public Dictionary<string, int> GetAgentSensors();
        public bool IsCorrect(string type, Dictionary<string, int> agentSensor);
        public bool IsExposed();
        public void UpdateExposedNum();
        public void GetValidSensorType();


    }
}

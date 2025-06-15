using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal abstract class IranianAgent
    {
        Sensor[] sensors;
        string rank;
        int sensorSlots;
        int exposedNum;

        internal abstract int GetSensorsCount();
        internal abstract Dictionary<string, int> GetAgentSensors();
        internal abstract bool IsCorrect(string type, Dictionary<string, int> agentSensor);
        internal abstract bool IsExposed();
        internal abstract void UpdateExposedNum();


    }
}

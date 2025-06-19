using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal interface IAgent
    {
        public string[] sensors { get;  set; }

        public bool[] isSensorExposed { get; set; }

        public List<ISensor> guessedSensors { get; set; }

        public string rank { get; set; }

        public int sensorSlots { get; set; }

        public int exposedNum { get; set; }

        public bool IsAttack { get; set; }

        public int turnCount { get; set; }

        public int attackNum { get; set; }
        public bool IsCorrect(string type);
        public void UpdateSensorToExposed(string type);
        public void UpdateSensorToUnExposed(string type);
        public bool IsExposed();
        public void AddExposedNum();
        public void SubExposedNum();
        public void RemoveSensor(int index);
        public void AttachingNewSensor(ISensor sensor);




    }
}

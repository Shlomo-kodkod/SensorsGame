using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class SquadLeader : IranianAgent
    {
        public SquadLeader(string[] sensor) : base(sensor)
        {
            this.rank = "Squad Leader";
            this.sensorSlots = 4;
            this.IsAttack = true;
            this.attackNum = 1;
        }
    }
}

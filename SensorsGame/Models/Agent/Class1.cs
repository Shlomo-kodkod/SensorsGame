using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class OrganizationLeader : IranianAgent
    {
        public OrganizationLeader(string[] sensor) : base(sensor)
        {
            this.rank = "Organization Leader";
            this.sensorSlots = 8;
            this.IsAttack = true;
            this.attackNum = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Players
    {
        public string userName;
        public string secretPass;
        public int gameLevel;
        public string agentType;
        public Players(string UserName, string SecretPass, int GameLevel, string AgentType)
        {
            this.userName = UserName;
            this.secretPass = SecretPass;
            this.gameLevel = GameLevel;
            this.agentType = AgentType;
        }
    }
}

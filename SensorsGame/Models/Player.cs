using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Player
    {
        public string userName;
        public string secretPass;
        public int gameLevel;
        public string agentType;
        public Player(string UserName, string SecretPass, int GameLevel, string AgentType)
        {
            this.userName = UserName;
            this.secretPass = SecretPass;
            this.gameLevel = GameLevel;
            this.agentType = AgentType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal class Program
    {
        internal static void Main()
        {
            Player p = PlayersDAL.GetPlayerData("dan", "SD21903i1");
            Console.WriteLine(p.agentType);
            PlayersDAL.UpdateLevel("dan", "SD21903i1", "Organization Leader");
            Console.WriteLine(PlayersDAL.IsUniqueUserName("dany"));
            Console.WriteLine(PlayersDAL.IsPlayerExist("dan", "SD21903i"));
            //Menu.DisplayEntryScreen();
            //Menu.Play();
        }
    }
}

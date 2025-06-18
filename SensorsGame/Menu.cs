using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsGame.Service;

namespace SensorsGame
{
    internal static class Menu
    {
        private static string[] levels = new string[] { "Foot Soldier", "Squad Leader", "Senior Commander", "Organization Leader" };
        public static void DisplayEntryScreen()
        {

            Console.WriteLine(
                """
                  _____                     _   _             _   _             
                  \_   \_ ____   _____  ___| |_(_) __ _  __ _| |_(_) ___  _ __  
                   / /\/ '_ \ \ / / _ \/ __| __| |/ _` |/ _` | __| |/ _ \| '_ \ 
                /\/ /_ | | | \ V /  __/\__ \ |_| | (_| | (_| | |_| | (_) | | | |
                \____/ |_| |_|\_/ \___||___/\__|_|\__, |\__,_|\__|_|\___/|_| |_|
                                                  |___/                         
                   ___                       __  
                  / _ \__ _ _ __ ___   ___   \ \ 
                 / /_\/ _` | '_ ` _ \ / _ \ (_) |
                / /_\\ (_| | | | | | |  __/  _| |
                \____/\__,_|_| |_| |_|\___| (_) |
                                             /_/ 
                """
                );
        }
        public static void Play()
        {
            DisplayEntryScreen();
            string[] playerInformation = PlayerIdentification.EnterToGame();
            string currLevel = "";
            bool IsStop = false;
            foreach(string newLevel in levels)
            {
                if(currLevel.Equals("Exit") || currLevel.Equals("Organization Leader"))
                {
                    IsStop = true;
                    break;
                }
                Agent agent = AgentFactory.InitAgent(newLevel);
                currLevel = GameManager.StartPlay(agent);
                PlayersDAL.UpdateLevel(playerInformation[0], playerInformation[1], agent.rank);
                Console.WriteLine((!IsStop) ? "":"Well done, you're starting the next level...");  
            }
        }

    }
}

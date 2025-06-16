using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class Menu
    {
        private static GameManager gameManager = new GameManager();
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
            gameManager.StartPlay();
        }




    }
}

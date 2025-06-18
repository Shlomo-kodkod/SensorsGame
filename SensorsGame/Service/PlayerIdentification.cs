using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class PlayerIdentification 
    {
        private static bool IsValidUserName(string userName)
        {
            if((userName.Equals(" ")) || (userName.Length < 1) || (userName is null))
            {
                return false;
            }
            return true;
        }
        private static string GetNewUserName()
        {
            string userName = "";
            do
            {
                Console.WriteLine("Enter user name: ");
                userName = Console.ReadLine();
                Console.WriteLine((!IsValidUserName(userName)) || (!PlayersDAL.IsUniqueUserName(userName)) ? "Invalid user name. Try again" : "");
            }
            while ((!IsValidUserName(userName)) || (!PlayersDAL.IsUniqueUserName(userName)));
            return userName;
        }
        private static string GetUserName()
        {
            string userName = "";
            do
            {
                Console.WriteLine("Enter user name: ");
                userName = Console.ReadLine();
                Console.WriteLine(!IsValidUserName(userName) ? "Invalid user name. Try again" : "");
            }
            while (!IsValidUserName(userName));
            return userName;
        }
        private static string GetPassword()
        {
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
            return pass;
        }
        private static string[] CreatNewPlayer()
        {
            string userName = GetNewUserName();
            string password = GetPassword();
            PlayersDAL.AddPlayer(userName, password, 1, "Foot Soldier");
            return new string[] {userName,password};
        }
        public static string[] EnterToGame()
        {
            string username = GetUserName();
            string password = GetPassword();

            if (PlayersDAL.IsPlayerExist(username,password))
            {
                return new string[] { username, password };
            }
            else if (PlayersDAL.IsUniqueUserName(username))
            {
                PlayersDAL.AddPlayer(username, password, 1, "Foot Soldier");
                return new string[] { username, password };
            }
            return CreatNewPlayer();
        }

    }
}

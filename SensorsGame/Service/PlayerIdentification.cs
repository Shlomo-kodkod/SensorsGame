using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class PlayerIdentification 
    {
        //Check to see if the name is validate.
        private static bool IsValidUserName(string userName)
        {
            if((userName.Equals(" ")) || (userName is null))
            {
                Console.WriteLine("Username can't be empty. Please try again.");
                return false;
            }
            else if(userName.Trim().Length < 4)
            {
                Console.WriteLine("Username must contains at least 4 characters.");
                return false;
            }
                return true;
        }

        //Create a new user name.
        private static string GetNewUserName()
        {
            string userName = "";
            do
            {
                Console.WriteLine("Enter a new user name of at least 4 characters: ");
                userName = Console.ReadLine();
                Console.WriteLine((!IsValidUserName(userName)) || (!PlayersDAL.IsUniqueUserName(userName)) ? "Invalid user name. Try again" : "");
            }
            while ((!IsValidUserName(userName)) || (!PlayersDAL.IsUniqueUserName(userName)));
            return userName;
        }

        //Returns the new user name
        private static string GetUserName()
        {
            string userName = "";
            do
            {
                Console.WriteLine("Enter your user name: ");
                userName = Console.ReadLine();
            }
            while (!IsValidUserName(userName));
            return userName;
        }

        //Returns the password.
        private static string GetPassword()
        {
            string pass = "";
            do
            {
                Console.WriteLine("Enter your Password: ");
                pass = Console.ReadLine();
                Console.WriteLine(pass.Trim().Length < 8 ? "Invalid password please try again. password must contains at least 8 characters.":"");
            }
            while (pass.Trim().Length < 8);
            return pass;
        }

        //Creates a new player and adds it to the database.
        private static string[] CreatNewPlayer()
        {
            string userName = GetNewUserName();
            string password = GetPassword();
            PlayersDAL.AddPlayer(userName, password, 1, "Foot Soldier");
            return new string[] {userName,password};
        }

        //Verifies the details of the player.
        //and creates a new player if it is not in the database.
        public static string[] EnterToGame()
        {
            string username = GetUserName();
            string password = GetPassword();

            if (PlayersDAL.IsPlayerExist(username,password))
            {
                return new string[] { username, password };
            }
            Console.WriteLine("You are not registered in the system.\n" +
                    "Please enter username and password to register.");
            return CreatNewPlayer();
        }

        //Checking whether the user connection was successful.
        public static bool IsAuthorized(string[] player)
        {
            if (player.Length == 2)
            {
                if(PlayersDAL.IsPlayerExist(player[0], player[1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

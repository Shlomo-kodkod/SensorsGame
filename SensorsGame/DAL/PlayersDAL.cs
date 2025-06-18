using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SensorsGame
{
    internal class PlayersDAL
    {
        private static string connStr = "server=localhost;user=root;password=;database=sensorsgame";

        //Adding a new player to the data base.
        public static void AddPlayer(string UserName, string SecretPass, int GameLevel, string AgentType)
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO players (userName,secretPass,gameLevel,agentType)" +
                    "VALUES (@userName,@secretPass,@gameLevel,@agentType)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", UserName);
                        cmd.Parameters.AddWithValue("@secretPass", SecretPass);
                        cmd.Parameters.AddWithValue("@gameLevel", GameLevel);
                        cmd.Parameters.AddWithValue("@agentType", AgentType);
                        cmd.ExecuteNonQuery();
                    }
                }

                FileLog.LogToFile(UserName, "Player successfully added");
                Console.WriteLine("New Player successfully added!");
            }
            catch (Exception ex)
            {
                FileLog.LogToFile(UserName, $"Failed to create a new player. Error: {ex.Message}");
                Console.WriteLine("Failed to create a new player");
            }
        }

        //Returns player data from the database.
        public static Player GetPlayerData (string user, string pass)
        {
            string query = $"SELECT * FROM players WHERE userName = @userName AND secretPass = @pass";
            Player player = null;

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", user);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (var reader = cmd.ExecuteReader())
                        {
                             if (reader.Read())
                            {
                                string userName = reader.GetString("userName");
                                string password = reader.GetString("secretPass");
                                int gameLevel = reader.GetInt32("gameLevel");
                                string agentType = reader.GetString("agentType");

                                player = new Player(userName, password, gameLevel, agentType);
                                FileLog.LogToFile(user, "Player data was successfully received");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                FileLog.LogToFile(user, $"Failed to get player data. Error: {ex}");
            }
            return player;
        }

        //Updates the current player level in the database.
        public static void UpdateLevel(string user, string pass, string type)
        {
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE players SET agentType = @level, gameLevel = gameLevel + 1 WHERE userName = @user AND secretPass = @pass";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@level", type);
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.ExecuteNonQuery();
                    }
                }
                FileLog.LogToFile(user, $"Level successfully update to {type}");
            }
            catch (Exception ex)
            {
                FileLog.LogToFile(user, $"Failed to update player level. Error: {ex}");
            }
        }

        //Checks whether the user name already exists in the database.
        public static bool IsUniqueUserName(string name)
        {
            string query = "SELECT COUNT(*) AS count FROM players WHERE userName = @name";
            int countName = 0;
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                countName = reader.GetInt32("count");
                                return countName == 0;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileLog.LogToFile(name, $"Checking is unique username Failed. Error : {ex.Message}");
            }
            return false;
        }

        //Check  if the player already exists in the database.
        public static bool IsPlayerExist(string user, string pass)
        {
            string query = $"SELECT id FROM players WHERE userName = @user AND secretPass = @password;";
            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@password", pass);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int currId = reader.GetInt32("id");
                                return currId != 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FileLog.LogToFile(user, $"Checking if player exist Failed. Error: {ex.Message}");
            }
            return false;
        }
    }
}

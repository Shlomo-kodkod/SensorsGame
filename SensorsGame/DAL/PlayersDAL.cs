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

                Console.WriteLine("New player successfully added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
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
                                
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            return player;
        }
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

                Console.WriteLine($"Level changed successfully to {type}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
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
                Console.WriteLine($"Error : {ex.Message}");
            }
            return false;
        }
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
                Console.WriteLine($"Error : {ex.Message}");
            }
            return false;
        }
    }
}

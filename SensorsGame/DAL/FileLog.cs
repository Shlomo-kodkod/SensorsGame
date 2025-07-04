﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsGame
{
    internal static class FileLog
    {
        //Returns the current time.
        private static DateTime GetTime()
        {
            return DateTime.Now;
        }

        //Create a log in format time name and operation.
        private static string CreatLog(string user, string log)
        {
            return $"[{GetTime()}] - {user} - {log}.";
        }

        //Create a log and write it to a file.
        public static void LogToFile(string user, string log)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Log.txt", true, Encoding.ASCII))
                {
                    string fullLog = CreatLog(user, log);
                    sw.WriteLine(fullLog);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            

        }


    }
}

﻿namespace MagicVilla_VillaAPI.Logging
{
    public class Logging2 : ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR - " + message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}

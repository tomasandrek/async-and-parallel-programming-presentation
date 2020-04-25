using System;

namespace ClientDemonstration
{
    public static class Utils
    {
        public static void ConsoleWrite(string data)
        {
            Console.WriteLine("[" + DateTime.Now + "]:" + data);
        }
    }
}
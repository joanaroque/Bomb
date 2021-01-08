using System;
using System.Collections.Generic;

namespace Bomb
{
    public class Log
    {
        public static void Add(string message)
        {

            Console.WriteLine(DateTime.Now + "|" + message);
        }

     
    }
}

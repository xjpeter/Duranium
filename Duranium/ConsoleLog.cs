using System;

using Duranium.Common;

namespace Duranium
{
    public class ConsoleLog : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
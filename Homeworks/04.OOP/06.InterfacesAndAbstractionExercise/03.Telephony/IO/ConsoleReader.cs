using _03.Telephony.IO.Contracts;
using System;

namespace _03.Telephony.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

    }
}

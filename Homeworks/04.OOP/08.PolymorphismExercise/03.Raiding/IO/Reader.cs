using System;

using _03.Raiding.IO.Contracts;

namespace _03.Raiding.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        => Console.ReadLine();
    }
}

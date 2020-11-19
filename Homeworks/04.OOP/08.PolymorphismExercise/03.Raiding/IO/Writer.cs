using System;

using _03.Raiding.IO.Contracts;

namespace _03.Raiding.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        => Console.Write(text);

        public void WriteLine(string text)
        => Console.WriteLine(text);
    }
}

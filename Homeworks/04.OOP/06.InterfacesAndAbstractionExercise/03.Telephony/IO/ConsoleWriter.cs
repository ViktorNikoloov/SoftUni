using _03.Telephony.IO.Contracts;
using System;

namespace _03.Telephony.IO 
{
    public int MyProperty { get; set; }

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        => Console.Write(text);


        public void WriteLine(string text)
        => Console.WriteLine(text);
    }
}

using System;

using Vehicles.IO.Contracts;

namespace Vehicles.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
       => Console.ReadLine();
    }
}

using System;

namespace _07.MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string CorpsExcMsg = "Invalid Corps!";
        public InvalidCorpsException()
            :base(CorpsExcMsg)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}

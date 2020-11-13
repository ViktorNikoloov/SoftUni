using System;

namespace _07.MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string StateExcMsg = "Invalid mission state!";

        public InvalidMissionStateException()
            :base(StateExcMsg)
        {

        }

        public InvalidMissionStateException(string message) 
            : base(message)
        {

        }
    }
}

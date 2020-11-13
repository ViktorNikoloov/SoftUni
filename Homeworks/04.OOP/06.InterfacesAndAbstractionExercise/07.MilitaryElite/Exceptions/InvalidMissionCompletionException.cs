using System;

namespace _07.MilitaryElite.Exceptions
{
    class InvalidMissionCompletionException : Exception
    {
        private const string InvalidMissionExcMsg = "Invalid mission already completed!";
        public InvalidMissionCompletionException()
            :base(InvalidMissionExcMsg)
        {

        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {

        }
    }
}

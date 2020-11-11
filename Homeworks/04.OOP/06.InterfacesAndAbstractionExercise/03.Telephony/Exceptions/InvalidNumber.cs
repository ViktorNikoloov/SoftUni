using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidNumber : Exception
    {
        public int MyProperty { get; set; }

        private const string NumberExsMsg = "Invalid number!";

        public InvalidNumber()
            :base(NumberExsMsg)
        {

        }

        public InvalidNumber(string message) 
            : base(message)
        {
        }
    }
}

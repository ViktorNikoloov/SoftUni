using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidUrl : Exception
    {
        public int MyProperty { get; set; }

        private const string UrlExceptionMsg = "Invalid URL!";

        public InvalidUrl()
            :base(UrlExceptionMsg)
        {

        }

        public InvalidUrl(string message) 
            : base(message)
        {

        }
    }
}

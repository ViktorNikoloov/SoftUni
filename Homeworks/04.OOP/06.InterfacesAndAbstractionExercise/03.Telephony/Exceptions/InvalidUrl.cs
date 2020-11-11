using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidUrl : Exception
    {

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

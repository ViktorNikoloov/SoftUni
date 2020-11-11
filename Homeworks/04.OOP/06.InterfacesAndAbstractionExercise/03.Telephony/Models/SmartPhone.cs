using System;
using System.Linq;

using _03.Telephony.Models.Contracts;
using _03.Telephony.Exceptions;

namespace _03.Telephony
{
    public class SmartPhone : ICallable, IBrowseable
    {
        public SmartPhone()
        {

        }
        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumber();
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {

            if (url.Any(x => char.IsNumber(x)))
            {
                throw new InvalidUrl();
            }

            return $"Browsing: {url}!";
        }

    }
}

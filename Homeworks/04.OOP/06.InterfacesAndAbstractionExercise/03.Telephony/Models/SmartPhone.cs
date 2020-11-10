using System;
using System.Linq;

using _03.Telephony.Models.Contracts;

namespace _03.Telephony.Models
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {

            if (url.Any(x => char.IsNumber(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

    }
}

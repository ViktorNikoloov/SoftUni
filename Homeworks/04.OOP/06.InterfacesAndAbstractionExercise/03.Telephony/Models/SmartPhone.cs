using _03.Telephony.Models.Contracts;
using System;
using System.Linq;


namespace _03.Telephony
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public SmartPhone()
        {

        }
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

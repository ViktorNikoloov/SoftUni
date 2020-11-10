using _03.Telephony.Models.Contracts;
using System;
using System.Linq;


namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {

        }

        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}

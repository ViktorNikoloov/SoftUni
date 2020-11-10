using System.Linq;

using _03.Telephony.Models.Contracts;
using _03.Telephony.Exceptions;

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
                throw new InvalidNumber();
            }

            return $"Dialing... {number}";
        }
    }
}

using _03.Telephony.Exceptions;
using _03.Telephony.IO.Contracts;

namespace _03.Telephony
{
    public class Engine
    {
        public int MyProperty { get; set; }

        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private SmartPhone smartPhone;

        private Engine()
        {
            stationaryPhone = new StationaryPhone();
            smartPhone = new SmartPhone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(' ');
            string[] sites = reader.ReadLine().Split(' ');

            CallTheNumbers(numbers);
            Browsing(sites);
        }

        private void Browsing(string[] sites)
        {

            foreach (var site in sites)
            {
                try
                {
                    writer.WriteLine(smartPhone.Browse(site));
                }
                catch (InvalidUrl iu)
                {
                    writer.WriteLine(iu.Message);
                }
            }

        }

        private void CallTheNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        writer.WriteLine(smartPhone.Call(number));
                    }
                    else
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                }
                catch (InvalidNumber ine)
                {
                    writer.WriteLine(ine.Message);
                }
            }

        }
    }
}

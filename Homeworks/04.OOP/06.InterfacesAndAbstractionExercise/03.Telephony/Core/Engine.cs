using System;

namespace _03.Telephony
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            CallTheNumbers(numbers);
            Browsing(sites);

        }

        private static void Browsing(string[] sites)
        {

            for (int i = 0; i < sites.Length; i++)
            {
                string currSite = sites[i];
                try
                {
                    SmartPhone smartPhone = new SmartPhone();
                    Console.WriteLine(smartPhone.Browse(currSite));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }


            }
        }

        private static void CallTheNumbers(string[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                string currNumber = numbers[i];
                try
                {
                    if (currNumber.Length == 10)
                    {
                        SmartPhone smartPhone = new SmartPhone();
                        Console.WriteLine(smartPhone.Call(currNumber));
                    }
                    else
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        Console.WriteLine(stationaryPhone.Call(currNumber));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}

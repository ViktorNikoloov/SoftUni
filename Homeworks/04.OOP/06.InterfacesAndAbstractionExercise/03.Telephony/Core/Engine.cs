using _03.Telephony.Models;
using System;

namespace _03.Telephony.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                CallTheNumbers();
                Browsing();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }


        }

        private static void Browsing()
        {
            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < sites.Length; i++)
            {
                string currSite = sites[i];

                SmartPhone smartPhone = new SmartPhone();
                Console.WriteLine(smartPhone.Browse(currSite));
            }
        }

        private static void CallTheNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            for (int i = 0; i < numbers.Length; i++)
            {
                string currNumber = numbers[i];

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
        }
    }
}

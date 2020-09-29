using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestsList = new HashSet<string>();

            string list = Console.ReadLine();
            while (list != "PARTY") //
            {
                guestsList.Add(list);

                list = Console.ReadLine();
            }

            string incoming = Console.ReadLine();
            while (incoming != "END") //
            {
                guestsList.Remove(incoming);

                incoming = Console.ReadLine();
            }
            Console.WriteLine(guestsList.Count);

            foreach (var vip in guestsList)
            {
                if (vip.ToCharArray()[0] >= '0' && vip.ToCharArray()[0]  <= '9')
                {
                    Console.WriteLine(vip);
                }

            }

            foreach (var guest in guestsList)
            {
                if (!(guest.ToCharArray()[0] >= '0' && guest.ToCharArray()[0] <= '9'))
                {
                    Console.WriteLine(guest);
                }

            }



        }
    }
}

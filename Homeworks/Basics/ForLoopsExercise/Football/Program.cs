using System;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Капацитетът на стадиона – цяло число в интервала[1 … 10000];
            //2.Броят на всички фенове – цяло число в интервала[1 … 10000].
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());

            int sectorA = 0;
            int sectorB = 0;
            int sectorV = 0;
            int sectorG = 0;
            //Секторът, на който се намира – текст – "A", "B", "V" и "G".
            for (int i = 0; i < fans; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A":
                        sectorA += 1;
                        break;

                    case "B":
                        sectorB += 1;
                        break;

                    case "V":
                        sectorV += 1;
                        break;

                    case "G":
                        sectorG += 1;
                        break;
                }
            }

            //процентите на феновете във всеки сектор, спрямо общия брой фенове на стадиона.
            Console.WriteLine($"{1.0 * sectorA / fans * 100:f2}%");
            Console.WriteLine($"{1.0 * sectorB / fans * 100:f2}%");
            Console.WriteLine($"{1.0 * sectorV / fans * 100:f2}%");
            Console.WriteLine($"{1.0 * sectorG / fans * 100:f2}%");

            //Kакто и общият процент на феновете за двата отбора, спрямо капацитета на стадиона.
            int allFans = sectorA + sectorB + sectorG + sectorV;
            Console.WriteLine($"{1.0 * allFans / stadiumCapacity * 100:f2}%");
        }
    }
}

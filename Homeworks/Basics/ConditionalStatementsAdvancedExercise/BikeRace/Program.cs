using System;

namespace BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Първият ред – броят младши велосипедисти.Цяло число в интервала[1…100]
            //Вторият ред – броят старши велосипедисти.Цяло число в интервала[1… 100]
            //Третият ред – вид трасе – "trail", "cross-country", "downhill" или "road"

            int juniorBikers = int.Parse(Console.ReadLine());
            int seniorBikers = int.Parse(Console.ReadLine());
            string roadtype = Console.ReadLine();

            double juniorFee = 0;
            double seniorFee = 0;


            //"trail", "cross-country", "downhill" или "road"

            switch (roadtype)
            {
                case "trail":
                    juniorFee = juniorBikers * 5.5;
                    seniorFee = seniorBikers * 7;
                    break;

                case "cross-country":
                    juniorFee = juniorBikers * 8;
                    seniorFee = seniorBikers * 9.5;
                    break;

                case "downhill":
                    juniorFee = juniorBikers * 12.25;
                    seniorFee = seniorBikers * 13.75;
                    break;

                case "road":
                    juniorFee = juniorBikers * 20;
                    seniorFee = seniorBikers * 21.5;
                    break;
            }

            double totalFee = juniorFee + seniorFee;

            if (roadtype == "cross-country")
            {
                if (juniorBikers + seniorBikers >= 50)
                {
                    totalFee *= 0.75;
                }
            }

            double charitySum = totalFee * 0.95;

            Console.WriteLine($"{charitySum:f2}");

        }
    }
}

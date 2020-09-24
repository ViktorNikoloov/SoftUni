using System;

namespace FlowersMore
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред е броят на закупените хризантеми – цяло число в интервала[0... 200]
            //•	На втория ред е броят на закупените рози – цяло число в интервала[0... 200]
            //•	На третия ред е броят на закупените лалета – цяло число в интервала[0... 200]
            //•	На четвъртия ред е посочен сезона – [Spring, Summer, Аutumn, Winter]
            //•	На петия ред е посочено дали денят е празник – [Y – да / N - не]

            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string ifHoliday = Console.ReadLine();

            double chrysanthemumsPrice = 0;
            double rosesPrice = 0;
            double tulipsPrice = 0;
            switch (season)
            {
                
                case "Spring":
                case "Summer":
                    chrysanthemumsPrice = chrysanthemums * 2.00;
                    rosesPrice = roses * 4.1;
                    tulipsPrice = tulips * 2.5;
                    break;

                case "Autumn":
                case "Winter":
                    chrysanthemumsPrice = chrysanthemums * 3.75;
                    rosesPrice = roses * 4.5;
                    tulipsPrice = tulips * 4.15;
                    break;
            }

            if (ifHoliday == "Y")
            {
                chrysanthemumsPrice *= 1.15;
                rosesPrice *= 1.15;
                tulipsPrice *= 1.15;
            }

            double bouquet = chrysanthemumsPrice + rosesPrice + tulipsPrice;

            if (season == "Spring")
            {
                if (tulips > 7)
                {
                    bouquet *= 0.95;
                }
            }

            if (season == "Winter")
            {
                if (roses >= 10)
                {
                    bouquet *= 0.90;
                }
            }

            if (season == "Spring" || season == "Summer" || season == "Autumn" || season == "Winter")
            {
                if (chrysanthemums + roses + tulips > 20)
                {
                    bouquet *= 0.80;
                }
            }

            Console.WriteLine($"{bouquet + 2:f2}");
        }
    }
}

using System;

namespace _4.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            //На първия ред – броя на групите от катерачи – цяло число в интервала[1...1000]
            int groupNumber = int.Parse(Console.ReadLine());
            double musalaGroup = 0;
            double monblanGroup = 0;
            double kilimandjaroGroup = 0;
            double kTwoGroup = 0;
            double everestGroup = 0;
            double allPeople = 0;


            for (int i = 0; i < groupNumber; i++)
            {
                //•	Група до 5 човека– Мусала
                //•	Група от 6 до 12 – Монблан
                //•	Група от 13 до 25 – Килиманджаро
                //•	Група от 26 до 40 – К2
                //•	Група от 41 или повече – Еверест
                double numberOfPeople = double.Parse(Console.ReadLine());
                allPeople += numberOfPeople;

                if (numberOfPeople <= 5)
                {
                    musalaGroup += numberOfPeople;
                }
                if (5 < numberOfPeople && numberOfPeople <= 12)
                {
                    monblanGroup += numberOfPeople;
                }
                if (12 < numberOfPeople && numberOfPeople <= 25)
                {
                    kilimandjaroGroup += numberOfPeople;
                }
                if (25 < numberOfPeople && numberOfPeople <= 40)
                {
                    kTwoGroup += numberOfPeople;
                }
                if (numberOfPeople >= 41)
                {
                    everestGroup += numberOfPeople;
                }
            }

            Console.WriteLine($"{musalaGroup / allPeople * 100:f2}%");
            Console.WriteLine($"{monblanGroup / allPeople * 100:f2}%");
            Console.WriteLine($"{kilimandjaroGroup / allPeople * 100:f2}%");
            Console.WriteLine($"{kTwoGroup / allPeople * 100:f2}%");
            Console.WriteLine($"{everestGroup / allPeople * 100:f2}%");

        }
    }
}

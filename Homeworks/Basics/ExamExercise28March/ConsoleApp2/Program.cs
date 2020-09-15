using System;

namespace упражнение
{
    class Program
    {
        static void Main(string[] args)
        {
            //•   На първия ред – броя на групите от катерачи – цяло число в интервала [1...1000]
            //•   За всяка една група на отделен ред – броя на хората в групата – цяло число в интервала [1...1000]
            int countClimber = int.Parse(Console.ReadLine());
            int sum = 0;
            int countGroup1 = 0;
            int countGroup2 = 0;
            int countGroup3 = 0;
            int countGroup4 = 0;
            int countGroup5 = 0;
            double percent1 = 0;
            double percent2 = 0;
            double percent3 = 0;
            double percent4 = 0;
            double percent5 = 0;
            int i = 1;
            while (i <= countClimber)
            {
                int countPeople = int.Parse(Console.ReadLine());
                //•   Група до 5 човека– Мусала
                //Група от 6 до 12 – Монблан
                //Група от 13 до 25 – Килиманджаро
                //Група от 26 до 40 – К2
                //Група от 41 или повече – Еверест
                if (countPeople <= 5)
                {
                    countGroup1 += countPeople;
                    sum += countPeople;

                }
                else if (countPeople >= 6 && countPeople <= 12)
                {
                    countGroup2 += countPeople;
                    sum += countPeople;
                }
                else if (countPeople >= 13 && countPeople <= 25)
                {
                    countGroup3 += countPeople;
                    sum += countPeople;
                }
                else if (countPeople >= 26 && countPeople <= 40)
                {
                    countGroup4 += countPeople;
                    sum += countPeople;
                }
                else if (countPeople >= 41)
                {
                    countGroup5 += countPeople;
                    sum += countPeople;

                }
                i++;
            }
            percent1 = (double)countGroup1 / sum * 100;
            percent2 = 1.0 * countGroup2 / sum * 100;
            percent3 = countGroup3 / (1.0 * sum) * 100;
            percent4 = (double)countGroup4 / sum * 100;
            percent5 = (double)countGroup5 / sum * 100;
            Console.WriteLine($"{percent1:f2}%");
            Console.WriteLine($"{percent2:f2}%");
            Console.WriteLine($"{percent3:f2}%");
            Console.WriteLine($"{percent4:f2}%");
            Console.WriteLine($"{percent5:f2}%");


        }
    }
}
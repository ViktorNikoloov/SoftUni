using System;

namespace _3.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	Сумата, с която разполагаме - реално число в интервала [10.00…1000.00]
            //•	Пол - символ('m' за мъж и 'f' за жена)
            //•	Възраст - цяло число в интервала[5…105]
            //•	Спорт - текст(една от възможностите в таблицата)
            double currMoney = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double cardPrice = 0;

            //Calculation
            //Пол   Gym Boxing Yoga Zumba Dances  Pilates
            //мъж	$42  $41    $45   $34   $51     $39
            //жена  $35  $37    $42   $31   $53     $37

            switch (gender)
            {
                case "m":
                    switch (sport)
                    {
                        case "Gym":
                            cardPrice = 42.00;
                            break;

                        case "Boxing":
                            cardPrice = 41.00;
                            break;

                        case "Yoga":
                            cardPrice = 45.00;
                            break;

                        case "Zumba":
                            cardPrice = 34.00;
                            break;

                        case "Dances":
                            cardPrice = 51.00;
                            break;

                        case "Pilates":
                            cardPrice = 39.00;
                            break;
                    }
                    break;

                case "f":
                    switch (sport)
                    {
                        case "Gym":
                            cardPrice = 35.00;
                            break;

                        case "Boxing":
                            cardPrice = 37.00;
                            break;

                        case "Yoga":
                            cardPrice = 42.00;
                            break;

                        case "Zumba":
                            cardPrice = 31.00;
                            break;

                        case "Dances":
                            cardPrice = 53.00;
                            break;

                        case "Pilates":
                            cardPrice = 37.00;
                            break;
                    }
                    break;
            }

            //Всички цени на карти за ученици(възраст под 19 години вкл.) са с 20 % намаление.
            if (age <= 19)
            {
                cardPrice *= 0.8;
            }
            if (cardPrice <= currMoney)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${cardPrice - currMoney:f2} more.");
            }

        }
    }
}

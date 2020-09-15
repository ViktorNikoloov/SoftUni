using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.На първия ред бюджетът на Ани – цяло число в интервала [1...1000]
            //2.На втория ред цената на плажната хавлия – реално число в интервала[1.00... 300.00]
            //3.На третия ред процентната отстъпка – цяло число в интервала[1...99]
            int budget = int.Parse(Console.ReadLine());
            double towel = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            //calculation
            //цената на чадъра е две трети от цената на хавлията
            //цената на джапанките е 75% от тази на плажния чадър
            //Плажната чанта струва една трета от сумата за джапанките и хавлията взети заедно
            //ще й бъде направена процентна отстъпка от общата сума на покупката.
            double umbrellaPrice = (towel * 2.0) / 3.0;
            double shoes = umbrellaPrice * 0.75;
            double bag = (towel + shoes) / 3.0;
            
            double sum = umbrellaPrice + shoes + bag + towel;
            double percenteges = sum * ((double)discount / 100);
            double totalSum = sum - percenteges;

            //output
            if (budget >= totalSum)
            {
                Console.WriteLine($"Annie's sum is {totalSum:f2} lv. She has {budget - totalSum:f2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Annie's sum is {totalSum:f2} lv. She needs {totalSum - budget:f2} lv. more.");
            }

        }
    }
}

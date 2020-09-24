using System;

namespace ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първия ред – броят биткойни. Цяло число в интервала[0…20]
            //•	На втория ред – броят китайски юана.Реално число в интервала[0.00… 50 000.00]
            //•	На третия ред – комисионната.Реално число в интервала[0.00... 5.00]
            int bitcoin = int.Parse(Console.ReadLine());
            double chineesUona = double.Parse(Console.ReadLine());
            double ChangeComission = double.Parse(Console.ReadLine());

            //Обменното бюро има комисионна от 0 до 5 процента от крайната сума в евро.
            //колко евро може да купи спрямо следните валутни курсове:
            //•	1 биткойн = 1168 лева. //•	1 евро = 1.95 лева.
            //•	1 китайски юан = 0.15 долара. //•	1 долар = 1.76 лева.

            double bitCoinToEuro = (bitcoin * 1168) / 1.95;
            double chineesUonaToEuro = ((chineesUona * 0.15) * 1.76) / 1.95;
            double totalEuro = bitCoinToEuro + chineesUonaToEuro;
            double commision = totalEuro * (ChangeComission / 100);

            Console.WriteLine($"{totalEuro - commision:f2}");
        }
    }
}

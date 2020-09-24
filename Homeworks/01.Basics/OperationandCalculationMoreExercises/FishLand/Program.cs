using System;

namespace FishLand
{
    class Program
    {
        static void Main(string[] args)
        {
            //Георги ще има гости вечерта и решава да ги нагости с паламуд, сафрид и миди. Затова отива на рибната борса, за да си купи по няколко килограма.

            //input
            //Oт конзолата се въвеждат цените в лева на скумрията и цацата. Също количеството на паламуд, сафрид и миди в килограми.

            double skumriaLv = double.Parse(Console.ReadLine());
            double cacaLv = double.Parse(Console.ReadLine());
            double palamudKg= double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            double midiKg = double.Parse(Console.ReadLine());

            //Calculation
            //цените на борсата са:
            // •Паламуд – 60 % по - скъп от скумрията
            //•	Сафрид – 80 % по - скъп от цацата
            //•	Миди – 7.50 лв.за килограм

            double palamudLv = skumriaLv + (skumriaLv * 0.6);
            double safridLv = cacaLv + (cacaLv * 0.8);
            double midiTotalSum= midiKg * 7.50;
            double totalSum = (palamudKg * palamudLv) + (safridKg * safridLv) + midiTotalSum;

            //output
            //Колко пари ще са му необходими, за да плати сметката си
            Console.WriteLine($"{totalSum:F2}");
        }
    }
}

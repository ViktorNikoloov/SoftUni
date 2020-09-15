using System;

namespace One
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	На първи ред, получавате брой пчели: цяло число [1-1000].
            //•	На втори ред получавате брой цветя: цяло число[1 - 10000].
            int bees = int.Parse(Console.ReadLine());
            int flowers = int.Parse(Console.ReadLine());

            //calculation
            //Всяка пчела произвежда 0.21 грама мед от всяко цвете. 
            //Една медена пита се запълва от 100 грама мед. 
            double honey = bees * flowers * 0.21;
            //Console.WriteLine(honey);
            double honeycomb = Math.Floor(honey / 100);
            //Console.WriteLine(honeycomb);
            double honeyLeft = honey - (honeycomb * 100);

            //output
            Console.WriteLine($"{honeycomb} honeycombs filled.");
            Console.WriteLine($"{honeyLeft:f2} grams of honey left.");

        }
    }
}

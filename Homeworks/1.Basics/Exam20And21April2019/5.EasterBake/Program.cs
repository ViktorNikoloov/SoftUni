using System;

namespace _5.EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Броят на козунаците – цяло число в интервала [1 ... 100]
            int easteBread = int.Parse(Console.ReadLine());
            int allSugarUsed = 0;
            int allFlourUsed = 0;
            int maxSugarValue = int.MinValue;
            int maxFlourValue = int.MinValue;

            //За всеки козунак се чете:
            for (int i = 0; i < easteBread; i++)
            {
                //o Количество изразходвана захар(грамове) – цяло число в интервала[1 … 10000]
                //o Количество изразходвано брашно(грамове) – цяло число в интервала[1 … 10000]
                int sugar = int.Parse(Console.ReadLine());
                int flour = int.Parse(Console.ReadLine());
                allSugarUsed += sugar;
                allFlourUsed += flour;

                if (sugar > maxSugarValue)
                {
                    maxSugarValue = sugar;
                }
                if (flour > maxFlourValue)
                {
                    maxFlourValue = flour;
                }

            }


            Console.WriteLine($"Sugar: {Math.Ceiling((double) allSugarUsed / 950)}");
            Console.WriteLine($"Flour: {Math.Ceiling((double) allFlourUsed / 750)}");
            Console.WriteLine($"Max used flour is {maxFlourValue} grams, max used sugar is {maxSugarValue} grams.");
        }
    }
}

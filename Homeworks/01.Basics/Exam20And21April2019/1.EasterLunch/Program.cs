using System;

namespace _1.EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //Брой козунаци - цяло число в интервала [0 … 99]
            //Брой кори с яйца - цяло число в интервала [0 … 99]
            //Килограми курабии - цяло число в интервала [0 … 99]
            int Easterbread = int.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int biscuits = int.Parse(Console.ReadLine());

            //calculation
            //Козунак  – 3.20 лв.
            //Яйца –  4.35 лв. за кора с 12 яйца
            //Курабии – 5.40 лв. за килограм
            //Боя за яйца - 0.15 лв. за яйце
            double breadPrice = Easterbread * 3.20;
            double eggsPrice = eggs * 4.35;
            double buscuitsPrice = biscuits * 5.40;
            double paintedEggs = (eggs * 12) * 0.15;
            double totalPrice = breadPrice + eggsPrice + buscuitsPrice + paintedEggs;

            //output
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}

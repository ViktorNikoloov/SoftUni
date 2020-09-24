using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditional
            //Работникът пуска тръбите едновременно и излиза за N часа. Напишете програма, която изкарва състоянието на басейна, в момента, когато работникът се върне. 

            // input
            // •Първият ред съдържа числото V – Обем на басейна в литри – цяло число в интервала[1…10000].
            //•	Вторият ред съдържа числото P1 – дебит на първата тръба за час – цяло число в интервала[1…5000].
            //•	Третият ред съдържа числото P2 – дебит на втората тръба за час– цяло число в интервала[1…5000].
            //•	Четвъртият ред съдържа числото H – часовете които работникът отсъства – реално число в интервала[1.0…24.00]

            int v = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            // calculation
            double volumeP1 = p1 * h;
            double volumeP2 = p2 * h;
            double pool = volumeP1 + volumeP2;
            //част / цялото * 100
            
            if (pool < v)
            {
                Console.WriteLine($"The pool is {pool /v * 100:f2}% full. Pipe 1: {volumeP1 / pool * 100:f2}%. Pipe 2: {volumeP2 / pool * 100:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {h:f2} hours the pool overflows with {pool - v:f2} liters.");
            }

        }
    }
}

using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wonBatlle = 0;

            string distance = Console.ReadLine();
            while (distance != "End of battle" && energy >= 0)
            {
                if (energy >= int.Parse(distance))
                {
                    wonBatlle++;
                    energy -= int.Parse(distance);
                    if (wonBatlle % 3 == 0)
                    {
                        energy += wonBatlle;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBatlle} won battles and {energy} energy");
                    return;
                }

                distance = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wonBatlle}. Energy left: {energy}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SantaPresentFactory17December2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] magicInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(materialsInput);
            Queue<int> magic = new Queue<int>(magicInput);

            int doll = 0; //150
            int train = 0; //250
            int bear = 0; //300
            int bicycle = 0; //400

            while (materials.Count != 0 && magic.Count != 0)
            {
                int currMaterial = materials.Peek();
                int currMagic = magic.Peek();
                int totalMagic = currMaterial * currMagic;

                if (totalMagic < 0)
                {
                    int sumMagic = materials.Pop() + magic.Dequeue();
                    materials.Push(sumMagic);
                    continue;

                }
                else if (currMagic == 0 && currMaterial == 0)
                {
                    materials.Pop();
                    magic.Dequeue();
                    continue;
                }
                else if (currMagic == 0)
                {
                    magic.Dequeue();
                    continue;
                }
                else if (currMaterial == 0)
                {
                    materials.Pop();
                    continue;
                }
                
                switch (totalMagic)
                {
                    case 150:
                        materials.Pop();
                        magic.Dequeue();
                        doll++;
                        break;

                    case 250:
                        materials.Pop();
                        magic.Dequeue();
                        train++;
                        break;

                    case 300:
                        materials.Pop();
                        magic.Dequeue();
                        bear++;
                        break;

                    case 400:
                        materials.Pop();
                        magic.Dequeue();
                        bicycle++;
                        break;

                    default:
                        magic.Dequeue();
                        materials.Push(materials.Pop() + 15);
                        break;
                }

            }

            Dictionary<string, int> orderedToys = new Dictionary<string, int>()
            {
                {"Doll", doll },
                {"Wooden train", train },
                {"Teddy bear", bear },
                {"Bicycle", bicycle }
            }.OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value);


            if ((0 < doll && train > 0) || (0 < bear && bicycle > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            foreach (var toy in orderedToys)
            {
                if (toy.Value != 0)
                {
                    Console.WriteLine($"{toy.Key}: {toy.Value}");

                }
            }

        }
    }
}

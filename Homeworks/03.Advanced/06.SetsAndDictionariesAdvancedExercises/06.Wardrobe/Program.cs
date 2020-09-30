using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                //string[] input = Console.ReadLine().Split(new string[] {" -> ", ","},StringSplitOptions.RemoveEmptyEntries);

                //string currColor = input[0];

                //for (int g = 1; g < input.Length; g++)
                //{
                //    string currCloth = input[g];
                //    if (!wardrobe.ContainsKey(currColor))
                //    {
                //        wardrobe.Add(currColor, new Dictionary<string, int>());
                //        wardrobe[currColor].Add(currCloth, 1);
                //    }
                //    else if(!wardrobe[currColor].ContainsKey(currCloth))
                //    {
                //        wardrobe[currColor].Add(currCloth, 1);
                //    }
                //    else
                //    {
                //        wardrobe[currColor][currCloth]++;
                //    }
                //}
                string[] command = Console.ReadLine().Split(new string[] {" -> "},StringSplitOptions.RemoveEmptyEntries);
                
                string currColor = command[0];
                string[] inputs = command[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var currCloth in inputs)
                {
                    if (!wardrobe.ContainsKey(currColor))
                    {
                        wardrobe.Add(currColor, new Dictionary<string, int>());
                        wardrobe[currColor].Add(currCloth, 1);
                    }
                    else if (!wardrobe[currColor].ContainsKey(currCloth))
                    {
                        wardrobe[currColor].Add(currCloth, 1);
                    }
                    else
                    {
                        wardrobe[currColor][currCloth]++;
                    }
                }


            }

            string[] searching = Console.ReadLine().Split().ToArray();
            string color = searching[0];
            string cloth = searching[1];

            foreach (var colors in wardrobe)
            {
                Console.WriteLine($"{colors.Key} clothes:");

                foreach(var clothes in colors.Value)
                {
                    if (colors.Key == color && clothes.Key == cloth)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                    Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }

        }
    }
}

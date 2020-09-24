using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            SortedDictionary<string, int> junks = new SortedDictionary<string, int>();
            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            int lastInput = 0;
            int count = 0;
            string obtainedItem = string.Empty;
            bool isObtained = false;
            
            while (isObtained == false)
            {
                string[] input = Console.ReadLine().Split();

                foreach (var item in input)
                {
                    count++;

                    if (count % 2 != 0)
                    {
                        lastInput = int.Parse(item);
                    }
                    else
                    {
                        string toLower = item.ToLower();
                        if (toLower == "shards" || toLower == "fragments" || toLower == "motes")
                        {
                            if (!items.ContainsKey(toLower))
                            {
                                items.Add(toLower, lastInput);

                                if (items[toLower] >= 250)
                                {
                                    obtainedItem = toLower;
                                    isObtained = true;
                                    break;
                                }
                            }
                            else
                            {
                                items[toLower] += lastInput;

                                if (items[toLower] >= 250)
                                {
                                    obtainedItem = toLower;
                                    isObtained = true;
                                    break;
                                }

                            }
                        }
                        else
                        {
                            if (!junks.ContainsKey(toLower))
                            {
                                junks.Add(toLower, lastInput);
                            }
                            else
                            {
                                junks[toLower] += lastInput;
                            }
                        }
                    }
                }

                
            }

            if (obtainedItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
                items[obtainedItem] -= 250;
            }
            else if (obtainedItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
                items[obtainedItem] -= 250;
            }
            else if (obtainedItem == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
                items[obtainedItem] -= 250;
            }

            var itemsOrdered = items.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

            foreach (var item in itemsOrdered)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            };

            foreach (var junk in junks)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            };
        }
    }
}

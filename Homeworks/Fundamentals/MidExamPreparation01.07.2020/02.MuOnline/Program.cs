using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            int health = 100;
            int bitcoins = 0;
            int count = 0;

            for (int i = 0; i < input.Count; i++)
            {
                string tempRoom = input[i];
                List<string> room = tempRoom.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                count++;

                if (room[0] == "potion")
                {
                    if (health + int.Parse(room[1]) > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        health += int.Parse(room[1]);
                        Console.WriteLine($"You healed for {int.Parse(room[1])} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (room[0] == "chest")
                {
                    bitcoins += int.Parse(room[1]);
                    Console.WriteLine($"You found {int.Parse(room[1])} bitcoins.");
                }
                else
                {
                    health -= int.Parse(room[1]);
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {room[0]}.");
                    }
                    else if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {room[0]}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }

                }

            }
            if (count == input.Count)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }

        }
    }
}

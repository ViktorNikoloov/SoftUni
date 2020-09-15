using System;

namespace MySimpleRPGGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, your name is:");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Hello, {playerName}");
            // player stats
            int playerHP = 100;
            int playerXP = 0;
            int playerLvl = 1;
            int playerAttack = 10;
            int playerCoins = 0;
            bool isAlive = true;

            int roomCount = 0;
            while (isAlive) //gameloop
            {
                roomCount++;
                Console.WriteLine($"=== room {roomCount} ===");
                int roomType = new Random().Next(1, 9);
                switch (roomType)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6: // meet a monster
                        int monsterType = new Random().Next(1, 4);
                        int monsterAttack = 0;
                        int monsterHP = 20;
                        string monsterName = "";
                        bool hasWon = false;
                        switch (monsterType)
                        {
                            case 1:
                                monsterName = "Spider";
                                monsterAttack = 4;
                                monsterHP = 11;
                                break;

                            case 2:
                                monsterName = "Bat";
                                monsterAttack = 6;
                                monsterHP = 24;
                                break;

                            case 3:
                                monsterName = "Wolf";
                                monsterAttack = 11;
                                monsterHP = 38;
                                break;

                        }

                        Console.WriteLine($"You've met a {monsterName}");
                        while (!hasWon && isAlive)
                        {
                            Console.WriteLine("What do you do?");
                            Console.WriteLine("1 - Fight");
                            Console.WriteLine("2 - Escape");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1) // Fight.
                            {
                                while (isAlive && !hasWon)
                                {
                                    monsterHP -= playerAttack;
                                    if (monsterHP <= 0)
                                    {
                                        Console.WriteLine("You won");
                                        playerXP += 1;
                                        if (playerXP > 100) // GainLevel()
                                        {
                                            playerLvl++;
                                            playerAttack += 10;
                                            playerXP -= 100;
                                        }

                                        hasWon = true;
                                        break;
                                    }

                                    playerHP -= monsterAttack;
                                    if (playerHP <= 0)
                                    {
                                        isAlive = false;
                                        break;
                                    }

                                    Console.WriteLine($"Player HP:{playerHP}");
                                    Console.WriteLine($"Monster HP:{monsterHP}");
                                }

                            }
                            else if (choice == 2)
                            {
                                int escapeChance = new Random().Next(1, 4);
                                if (escapeChance == 1)
                                {
                                    Console.WriteLine("You've ran away!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You were too slow");
                                }

                            }

                        }
                        break;

                    case 7:
                        int chestCoins = new Random().Next(15, 100);
                        playerCoins += chestCoins;
                        Console.WriteLine($"You've found a chest with {chestCoins}");
                        break;

                    case 8:
                        Console.WriteLine("You've found a potion");
                        playerHP += 10;
                        break;

                    case 9:
                        Console.WriteLine("Shop not Implemented yet");
                        // Shop 
                        // Some items with coins
                        break;

                }

            }

            Console.WriteLine("Game over");
            Console.WriteLine($"Coins: {playerCoins}");
        }
    }
}
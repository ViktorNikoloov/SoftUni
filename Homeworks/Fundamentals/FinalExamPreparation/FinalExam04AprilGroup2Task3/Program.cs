using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam04AprilGroup2Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(); //{hero name} {HP} {MP} 
                string name = info[0]; int HP = int.Parse(info[1]), MP = int.Parse(info[2]);

                Hero hero = new Hero();
                hero.HP = HP; //maximum of 100 HP
                hero.MP = MP; //maximum of 200 MP

                heroes.Add(name, hero);
            }

            string[] command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            while (!(command.Contains("End")))
            {
                string heroName = command[1];

                if (command.Contains("CastSpell")) //{hero name} – {MP needed} – {spell name} 
                {
                    int MP = int.Parse(command[2]);
                    string spell = command[3];

                    if (heroes[heroName].MP >= MP)
                    {
                        heroes[heroName].MP -= MP;

                        if (heroes[heroName].MP < 0)
                        {
                            heroes[heroName].MP = 0;
                        }
                        Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroes[heroName].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                    }

                }
                else if (command.Contains("TakeDamage")) //{hero name} – {damage} – {attacker}
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    heroes[heroName].HP -= damage;

                    if (heroes[heroName].HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                   
                }
                else if (command.Contains("Recharge")) // {hero name} – {amount}
                {
                    int amount = int.Parse(command[2]);
                    if (heroes[heroName].MP + amount <= 200)
                    {
                        heroes[heroName].MP += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName].MP} MP!");
                        heroes[heroName].MP = 200;
                    }
                    
                }
                else if (command.Contains("Heal")) // {hero name} – {amount}
                {
                    int amount = int.Parse(command[2]);
                    if (heroes[heroName].HP + amount <= 100)
                    {
                        heroes[heroName].HP += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroes[heroName].HP} HP!");
                        heroes[heroName].HP = 100;

                    }


                }

                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (var hero in heroes.OrderByDescending(x => x.Value.HP).ThenBy(x => x.Key))
            {
                Console.WriteLine(@$"{hero.Key}
  HP: {hero.Value.HP}
  MP: {hero.Value.MP}");
            }

        }
    }

    class Hero
    {
        public int HP { get; set; }

        public int MP { get; set; }
    }
}

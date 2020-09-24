using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            int cents = (int) (change * 100);
            int coins = 0;

            
            int remainder = cents % 200;
            coins += cents / 200;
            cents = remainder;

            remainder = cents % 100;
            coins += cents / 100;
            cents = remainder;

            remainder = cents % 50;
            coins += cents / 50;
            cents = remainder;

            remainder = cents % 20;
            coins += cents / 20;
            cents = remainder;

            remainder = cents % 10;
            coins += cents / 10;
            cents = remainder;

            remainder = cents % 5;
            coins += cents / 5;
            cents = remainder;

            remainder = cents % 2;
            coins += cents / 2;
            cents = remainder;

            remainder = cents % 1;
            coins += cents / 1;
            cents = remainder;

            Console.WriteLine(coins);
        }
    }
}

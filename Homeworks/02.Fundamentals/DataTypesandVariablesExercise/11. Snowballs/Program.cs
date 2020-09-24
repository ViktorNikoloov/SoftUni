using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger highestScore = BigInteger.Zero;
            int highestSnowballSnow = int.MinValue;
            int shighestSnowballTime = int.MinValue;
            int shighestSnowballQuality = int.MinValue;

            for (int i = 0; i < snowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > highestScore)
                {
                    highestScore = snowballValue;
                    highestSnowballSnow = snowballSnow;
                    shighestSnowballTime = snowballTime;
                    shighestSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{highestSnowballSnow} : {shighestSnowballTime} = {highestScore} ({shighestSnowballQuality})");

        }
    }
}

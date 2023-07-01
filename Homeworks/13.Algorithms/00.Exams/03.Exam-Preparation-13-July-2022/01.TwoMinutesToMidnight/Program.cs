namespace _01.TwoMinutesToMidnight
{
    using System;
    using System.Numerics;

    internal class Program
    {
        private static Dictionary<string, ulong> cache;
        static void Main(string[] args)
        {
            cache = new Dictionary<string, ulong>();

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            //BigInteger binomalCoefficient = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));
            ulong binomalCoefficient = GetBinomalCoefficient(n, k);
            
            Console.WriteLine(binomalCoefficient);
        }

        private static ulong GetBinomalCoefficient(int row, int col)
        {

            if (col == 0 || col == row )
            {
                return 1;
            }

            string indentifier = $"{row}-{col}";
            if (cache.ContainsKey(indentifier))
            {
                return cache[indentifier];
            }


            ulong result = GetBinomalCoefficient(row - 1, col - 1) + GetBinomalCoefficient(row - 1, col);
            cache[indentifier] = result;

            return result;
        }

        private static BigInteger GetFactorial(int n)
        {
            BigInteger factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
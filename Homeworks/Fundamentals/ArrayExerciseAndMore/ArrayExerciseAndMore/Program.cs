using System;

namespace ArrayExerciseAndMore
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagon = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagon];
            int sum = 0;

            for (int i = 0; i < wagons.Length; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }

            Console.WriteLine(string.Join(" ", wagons));
            Console.WriteLine(sum);

        }
    }
}

using System;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            string temp = "";

            for (int i = 0; i < n; i++) // 51 47 32 61 21
            {
                temp = array[0];
                for (int j = 1; j < array.Length; j++)
                {
                    array[j - 1] = array[j];
                }
               array[array.Length - 1] = temp;
            }
            
            Console.WriteLine(String.Join(" ", array));
        }
    }
}

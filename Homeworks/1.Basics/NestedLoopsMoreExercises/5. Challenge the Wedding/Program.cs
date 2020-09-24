using System;

namespace _5._Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int table = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isTableLimit = false;
            bool isPeopleMet = false;
 
                for (int i = 1; i <= men; i++)
                {

                    for (int a = 1; a <= women; a++)
                    {
                        
                        if (counter >= table)
                        {
                            isTableLimit = true;
                            break;
                        }
                        counter++;
                        Console.Write($"({i} <-> {a}) ");
                        if (i == men && a == women)
                        {
                            isPeopleMet = true;
                            break;
                        }
                    }
                    if (isTableLimit)
                    {
                        break;
                    }
                    if (isPeopleMet)
                    {
                        break;
                    }
                }
        }
    }
}

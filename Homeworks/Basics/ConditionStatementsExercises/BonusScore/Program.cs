using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            number += int.Parse(Console.ReadLine());
            double bonus = 0.0;
            // if number <=100 --> bonus + 5 
            // if number > 100 --> bonus + 20% of the number
            // if number > 1000 --> bonus + 10% of the number

            //•	Допълнителни бонус точки(начисляват се отделно от предходните):
            //o За четно число  +1 т.
            //o За число, което завършва на 5  +2 т.

            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number > 1000)
            {
                bonus += number * 0.1;
            }
            else
            {
                bonus += number * 0.2;
            }
            if (number % 2 == 0)
            {
                bonus += 1;

            }
            else if (number % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(number + bonus);

        }
    }
}

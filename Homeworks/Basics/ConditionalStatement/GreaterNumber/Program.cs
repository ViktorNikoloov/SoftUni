using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conditional
            //Да се напише програма, която чете две цели числа въведени от потребителя и отпечатва по-голямото от двете. 

            // input
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            // Calculation
            if (numberOne > numberTwo)
            {
                Console.WriteLine(numberOne);
            }
            else
                Console.WriteLine(numberTwo);
            
        }
    }
}

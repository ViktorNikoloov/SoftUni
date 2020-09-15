using System;

namespace Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Брой бутилки от препарат
            int numberOfBottles = int.Parse(Console.ReadLine());
            int quantity = numberOfBottles * 750;
            int timeCount = 0;
            bool isEmpty = true;
            int platesCount = 0;
            int potsCount = 0;
            int potsAndPlatesQuantity = 0;

            //До получаване на командата "End" или докато количеството препарат не се изчерпи.
            //Брой съдове, които трябва да бъдат измити.
            while (quantity >= potsAndPlatesQuantity)
            {
                timeCount++;
                string dishes = Console.ReadLine();
                if (dishes == "End")
                {
                    isEmpty = false;
                    break;
                }

                if (timeCount % 3 == 0)
                {
                    int pots = int.Parse(dishes);
                    potsCount += pots;
                    potsAndPlatesQuantity += pots * 15;
                    continue;
                }

                int plate = int.Parse(dishes);
                platesCount += plate;
                potsAndPlatesQuantity += plate * 5;
            }


            if (isEmpty == false)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{platesCount} dishes and {potsCount} pots were washed.");
                Console.WriteLine($"Leftover detergent {quantity - potsAndPlatesQuantity} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {potsAndPlatesQuantity - quantity} ml. more necessary!");
            }
        }
    }
}

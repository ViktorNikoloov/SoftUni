using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            //•	На първия ред - минути разходка на ден - цяло число в интервала [1...50]
            //•	На втория ред - броят на разходките дневно - цяло число в интервала[1…10]
            //•	На третия ред - приетите от котката калории на ден – цяло число в интервала[100…4000]
            int minutes = int.Parse(Console.ReadLine());
            int outside = int.Parse(Console.ReadLine());
            int eatCalories = int.Parse(Console.ReadLine());

            //calculation
            //За всяка минута от разходката, котката гори по 5 калории. 
            int burnCalories = minutes * outside * 5;

            // Разходката е достатъчна, ако котката изграря 50 % от приетите калории.
            if (burnCalories >= eatCalories / 2 )
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnCalories}.");
            }


        }
    }
}

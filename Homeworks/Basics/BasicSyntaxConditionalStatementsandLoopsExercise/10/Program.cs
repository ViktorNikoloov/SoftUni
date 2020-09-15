using System;

namespace _9.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //•	On the first input line - lost games count – integer in the range [0, 1000].
            //•	On the second line – headset price - floating point number in range [0, 1000]. 
            //•	On the third line – mouse price - floating point number in range [0, 1000].
            //•	On the fourth line – keyboard price - floating point number in range [0, 1000]. 
            //•	On the fifth line – display price - floating point number in range [0, 1000]. 
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double price = 0;
            int keyboardCount = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                bool isheadset = false;
                bool ismouse = false;
                if (i % 2 == 0)
                {
                    price += headsetPrice;
                    isheadset = true;
                }
                if (i % 3 == 0)
                {
                    price += mousePrice;
                    ismouse = true;
                }
                if (isheadset == true && ismouse == true)
                {
                    price += keyboardPrice;
                    keyboardCount++;
                    if (keyboardCount == 2)
                    {
                        price += displayPrice;
                        keyboardCount = 0;
                    }
                }
            }
            Console.WriteLine($"Rage expenses: {price:f2} lv.");

        }
    }
}

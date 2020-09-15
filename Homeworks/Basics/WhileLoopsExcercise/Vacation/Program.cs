using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Пари нужни за екскурзията
            double neededMoney = double.Parse(Console.ReadLine());
            //Налични пари
            double savedMoney = double.Parse(Console.ReadLine());
            int pastDays = 0;
            double allMoney = savedMoney;
            int spendMoneyDays = 0;

            while (allMoney < neededMoney)
            {
                //"spend" or "save".
                string SpendOrSave = Console.ReadLine();
                double spendOrSaveMoney = double.Parse(Console.ReadLine());
                pastDays++;

                if (SpendOrSave == "spend")
                {
                    spendMoneyDays++;
                    allMoney -= spendOrSaveMoney;

                    if (allMoney < 0)
                    {
                        allMoney = 0;
                    }

                    if (spendMoneyDays >= 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine($"{pastDays}");
                        break;
                    }
                        
                }
                else
                {
                    spendMoneyDays = 0;
                    allMoney += spendOrSaveMoney;
                }


            }

            if (allMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {pastDays} days.");
            }

        }
    }
}

using System;

namespace _3._MobileОperator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Срок на договор "one", или "two"
            //Тип на договор "Small",  "Middle", "Large"или "ExtraLarge"
            //Добавен мобилен интернет "yes" или "no"
            //Брой месеци за плащане 1-24
            string contractDuration = Console.ReadLine();
            string typeOfContract = Console.ReadLine();
            string mobileData = Console.ReadLine();
            int numberOfMounths = int.Parse(Console.ReadLine());
            double priceOfContract = 0;

            switch (contractDuration)
            {
                //"Small",  "Middle", "Large"или "ExtraLarge"
                case "one":
                    switch (typeOfContract)
                    {
                        case "Small":
                            priceOfContract = 9.98;
                            break;

                        case "Middle":
                            priceOfContract = 18.99;
                            break;

                        case "Large":
                            priceOfContract = 25.98;
                            break;

                        case "ExtraLarge":
                            priceOfContract = 35.99;
                            break;
                    }
                    break;

                case "two":
                    switch (typeOfContract)
                    {
                        case "Small":
                            priceOfContract = 8.58;
                            break;

                        case "Middle":
                            priceOfContract = 17.09;
                            break;

                        case "Large":
                            priceOfContract = 23.59;
                            break;

                        case "ExtraLarge":
                            priceOfContract = 31.79;
                            break;
                    }
                    break;
            }

            //по-малка или равна на 10.00 лв. 🡪 5.50 лв.
            //такса по-малка или равна на 30.00 лв. 🡪 4.35 лв.
            //такса по-голяма от 30.00 лв. 🡪 3.85 лв.
            if (mobileData == "yes")
            {
                if (0.00 < priceOfContract && priceOfContract <= 10.00)
                {
                    priceOfContract += 5.50;
                }
                else if (10.00 < priceOfContract && priceOfContract <= 30.00)
                {
                    priceOfContract += 4.35;
                }
                else if (priceOfContract > 30.00)
                {
                    priceOfContract += 3.85;
                }
            }
            if (contractDuration == "two")
            {
                priceOfContract *= (1 - 0.0375);
            }

            Console.WriteLine($"{priceOfContract * numberOfMounths:f2} lv.");
        }
    }
}

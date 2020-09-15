using System;

namespace TailoringWorshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            double lendgth = double.Parse(Console.ReadLine());
            double wedth = double.Parse(Console.ReadLine());
            
            //Покривките са правоъгълни, каретата са квадратни, броят им винаги е еднакъв. 
            //Покривката трябва да виси с 30 см от всеки ръб на масата. 
            //Страната на каретата е половината от дължината на масите. 
            //Във всяка поръчка се включва информация за броя и размерите на масите.

            double tablecloth = amount * (lendgth + 2 * 0.30) * (wedth + 2 * 0.30);
            double quads = amount * (lendgth / 2) * (lendgth / 2);
            double tableclothPrice = tablecloth * 7;
            double quadsprice = quads * 9;

            //"{цена в долари} USD"
            //"{цена в левове} BGN"
            //Резултатите да се форматира до два знака след  десетичната запетая.
            //като квадратен метър плат за правоъгълна покривка струва 7 долара, а за каре – 9 долара. 
            //Курсът на долара е 1.85 лева.  

            Console.WriteLine($"{tableclothPrice + quadsprice:F2} USD");
            Console.WriteLine($"{(tableclothPrice + quadsprice) * 1.85:F2} BGN");
        }
    }
}

using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 year = 48 weekends
            //Влади играе в София всяка събота:
            //в 2/3 от празничните дни.
            //пътува до родния си град h пъти където играе волейбол в неделя
            //Влади не е на работа 3/4 от уикендите
            //високосните години Влади играе с 15% повече 
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsHomeTown = double.Parse(Console.ReadLine());

            double games = 0;

            games = (((48 - weekendsHomeTown) * 3) / 4) + ((holidays * 2) / 3) + weekendsHomeTown;

            if (year == "leap")
            {
                games *= 1.15;
                Console.WriteLine(Math.Floor(games));
            }
            else
            {
                Console.WriteLine(Math.Floor(games));
            }

        }
    }
}

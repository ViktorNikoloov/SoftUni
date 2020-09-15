using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                 "I can’t live without this product."
            };
            List<string> events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana", 
                "Petya", 
                "Stella", 
                "Elena", 
                "Katya", 
                "Iva", 
                "Annie", 
                "Eva"
            };
            List<string> cities = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int n = int.Parse(Console.ReadLine());

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int phraseRand = rand.Next(0, phrases.Count - 1);
                int eventRand = rand.Next(0, events.Count - 1);
                int authorRand = rand.Next(0, authors.Count - 1);
                int citiesRand = rand.Next(0, cities.Count - 1);

                Console.WriteLine($"{phrases[phraseRand]} {events[eventRand]} {authors[authorRand]} – {cities[citiesRand]}");
            }

        }
    }
}

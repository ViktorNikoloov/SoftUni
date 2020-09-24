using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;
            string searchBook = "";
            bool isValid = false;
            while (searchBook != bookName)
            {
                searchBook = Console.ReadLine();
                if (searchBook == bookName)
                {
                    isValid = true;
                    break;
                }
                counter++;

                if (counter >= capacity)
                {
                    break;
                }
                
            }

            if (isValid)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}

using System;

namespace OldBooksWithForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string Bookname = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < capacity; i++)
            {
                string search = Console.ReadLine();
                counter++;

                if (search == Bookname )
                {
                    Console.WriteLine($"You checked {i} books and found it.");
                    break;
                }
                
            }
            if (counter == capacity)
            {
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {counter} books.");

            }
        }
    }
}

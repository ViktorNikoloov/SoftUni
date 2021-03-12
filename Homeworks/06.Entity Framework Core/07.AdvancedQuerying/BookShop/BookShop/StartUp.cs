namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            ////01.AgeRestriction
            //var input = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result);

            ////02.Golden Books
            //var result = GetGoldenBooks(db);
            //Console.WriteLine(result);

            ////03.Books by Price
            //var result = GetBooksByPrice(db);
            //Console.WriteLine(result);

            ////03.Not Released In
            //var year = int.Parse(Console.ReadLine());
            //var result = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(result);

            //06.Book Titles by Category
            var book = Console.ReadLine();
            var result = GetBooksByCategory(db, book);
            Console.WriteLine(result);

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var titles = context
                .Books
                .AsEnumerable()
                .Where(t => t.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();

            // return string.Join(Environment.NewLine, titles);

        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(c => c.EditionType.ToString() == "Gold" && c.Copies < 5000)
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();

            // return string.Join(Environment.NewLine, books);

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(p => p.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(x => x.BookPrice)
                .ToList();


            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                 .Books
                 .Where(x => x.ReleaseDate.Value.Year != year)
                 .Select(b => new
                 {
                     BookId = b.BookId,
                     BookTitle = b.Title
                 })
                 .OrderBy(x => x.BookId)
                 .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
            // return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(c => c.ToLower())
                           .ToArray();

            List<string> bookTitles = new List<string>();
            foreach (var category in categories)
            {
                List<string> currBookTitle = context
                     .BooksCategories
                     .Where(bc => bc.Category.Name.ToLower() == category)
                     .Select(bc => bc.Book.Title)
                     .ToList();

                bookTitles.AddRange(currBookTitle);
            }

            bookTitles = bookTitles.OrderBy(x => x).ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }
    }

}

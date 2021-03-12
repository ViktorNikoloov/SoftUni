namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            ////02.AgeRestriction
            //var input = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result);

            ////03.Golden Books
            //var result = GetGoldenBooks(db);
            //Console.WriteLine(result);

            ////04.Books by Price
            //var result = GetBooksByPrice(db);
            //Console.WriteLine(result);

            ////05.Not Released In
            //var year = int.Parse(Console.ReadLine());
            //var result = GetBooksNotReleasedIn(db, year);
            //Console.WriteLine(result);

            ////06.Book Titles by Category
            //var book = Console.ReadLine();
            //var result = GetBooksByCategory(db, book);
            //Console.WriteLine(result);

            ////07.Released Before Date
            //var date = Console.ReadLine();
            //var result = GetBooksReleasedBefore(db, date);
            //Console.WriteLine(result);

            ////08.Author Search
            //var input = Console.ReadLine();
            //var result = GetAuthorNamesEndingIn(db, input);
            //Console.WriteLine(result);


            ////09.Book Search
            var input = Console.ReadLine();
            var result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);
        }

        //02.AgeRestriction
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

        //03.Golden Books
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

        //04.Books by Price
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

        //05.Not Released In
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

        //06.Book Titles by Category
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

        //07.Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateInFormat = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(x => x.ReleaseDate < dateInFormat)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookType = b.EditionType,
                    BookPrice = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - {book.BookType} - ${book.BookPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //08.Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                            .Authors
                            .Where(a => a.FirstName.EndsWith(input))
                            .Select(a => a.FirstName + " " + a.LastName)
                            .OrderBy(x => x)
                            .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author}");
            }

            return sb.ToString().TrimEnd();

        }

        //09.Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //Return the titles of book, which contain a given string. Ignore casing.
            //Return all titles in a single string, each on a new row, ordered alphabetically.
            string lowerInput = input.ToLower();

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(lowerInput))
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

    }

}

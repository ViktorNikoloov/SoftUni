﻿namespace BookShop
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
            //var input = Console.ReadLine();
            //var result = GetBookTitlesContaining(db, input);
            //Console.WriteLine(result);

            //10.Book Search by Author
            //var input = Console.ReadLine();
            //var result = GetBooksByAuthor(db, input);
            //Console.WriteLine(result);

            ////11.Count Books
            //var lengthCheck = int.Parse(Console.ReadLine());
            //var result = CountBooks(db, lengthCheck);
            //Console.WriteLine($"There are {result} books with longer title than {lengthCheck} symbols");

            ////12.Total Book Copies
            //var result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            ////13.Profit by Category
            //var result = GetTotalProfitByCategory(db);
            //Console.WriteLine(result);

            ////14.Most Recent Books
            //var result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            ////15.Increase Prices
            //IncreasePrices(db);

            //////16.Remove Books
            //var result = RemoveBooks(db);
            //Console.WriteLine(result);
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
            //string lowerInput = input.ToLower();

            var books = context
                .Books
                //.Where(b => b.Title.ToLower().Contains(lowerInput))
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //10.Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //Return all titles of books and their authors’ names for books, which are written by authors whose last names start with the given string.
            //Return a single string with each title on a new row.Ignore casing.Order by book id ascending.
            string lowerInput = input.ToLower();

            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(lowerInput))
                .OrderBy(x => x.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        //11.Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //Return the number of books, which have a title longer than the number given as an input.

            var result = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return result;
        }

        //12.Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var results = context
                           .Authors
                           .Select(a => new
                           {
                               FullName = a.FirstName + " " + a.LastName,
                               TotalCopies = a.Books.Sum(b => b.Copies)

                           })
                           .OrderByDescending(x => x.TotalCopies)
                           .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var result in results)
            {
                sb.AppendLine($"{result.FullName} - {result.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13.Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profits = context
                .Categories
                .Select(bc => new
                {
                    CategoryName = bc.Name,
                    TotalProfit = bc.CategoryBooks
                        .Select(b => new
                        {
                            BookProfit = b.Book.Copies * b.Book.Price
                        })
                        .Sum(x => x.BookProfit)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var profit in profits)
            {
                sb.AppendLine($"{profit.CategoryName} ${profit.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14.Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var Categories = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        BooksReleaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.BooksReleaseDate)
                    .Take(3)
                    .ToList()

                })
                .OrderBy(x => x.CategoryName)
                .ToList();



            StringBuilder sb = new StringBuilder();
            foreach (var Category in Categories)
            {
                sb.AppendLine($"--{Category.CategoryName}");

                foreach (var book in Category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BooksReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15.Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            //context
            //    .Books
            //    .Where(b => b.ReleaseDate.Value.Year < 2010)
            //    .ToList()
            //    .ForEach(b => b.Price += 5);

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16.Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var updatedBooks = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            foreach (var book in updatedBooks)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            var result = updatedBooks.Count();

            return result;
        }

    }

}

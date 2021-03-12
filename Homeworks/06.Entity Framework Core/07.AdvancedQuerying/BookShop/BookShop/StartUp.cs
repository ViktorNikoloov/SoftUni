namespace BookShop
{
    using Data;
    using Initializer;
    using System;
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

            //03.Books by Price
            var result = GetBooksByPrice(db);
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
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(c=>c.EditionType.ToString() == "Gold" && c.Copies < 5000)
                .Select(b=> new 
                {
                    BookId = b.BookId,
                    BookTitle = b.Title
                })
                .OrderBy(x=>x.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book.BookTitle);
            }

            return sb.ToString().TrimEnd();
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
    }
}

namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto.OldestBooksXml;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                 .Authors
                 .Select(a => new
                 {
                     AuthorName = a.FirstName + " " + a.LastName,
                     Books = a.AuthorsBooks
                        .OrderByDescending(b => b.Book.Price)
                         .Select(b => new
                         {
                             BookName = b.Book.Name,
                             BookPrice = b.Book.Price.ToString("F2")
                         })
                         .ToList()
                 })
                 .ToList()
                 .OrderByDescending(a => a.Books.Count)
                 .ThenBy(a => a.AuthorName)
                 .ToList();

            var jsonResult = JsonConvert.SerializeObject(authors,Formatting.Indented);

            return jsonResult;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            const string root = "Books";

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add(string.Empty, string.Empty);

            var oldestBooks = context
                .Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(b => b.Pages)
                .OrderByDescending(b=>b.PublishedOn)
                .Select(b => new OldestBooks()
                {
                    Pages = b.Pages.ToString(),
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .Take(10)
                .ToArray();



            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OldestBooks[]), new XmlRootAttribute(root));
            xmlSerializer.Serialize(textWriter, oldestBooks, nameSpace);

            return textWriter.ToString().TrimEnd();


        }
    }
}
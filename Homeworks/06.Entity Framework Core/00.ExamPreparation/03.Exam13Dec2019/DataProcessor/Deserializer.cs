namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Newtonsoft.Json;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    using BookShop.Data.Models;

    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto.ImportBooks;
    using BookShop.DataProcessor.ImportDto.ImportBooks.ImportAuthors;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var textReader = new StringReader(xmlString);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBooksXmlModel[]), new XmlRootAttribute("Books"));

            var booksXml = xmlSerializer.Deserialize(textReader) as ImportBooksXmlModel[];

            foreach (var bookXml in booksXml)
            {
                var isDateValid = DateTime.TryParseExact(bookXml.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var publishedOn);

                if (!IsValid(bookXml) || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = bookXml.Name,
                    Genre = (Genre)bookXml.Genre,
                    Price = decimal.Parse(bookXml.Price.ToString("F2")),
                    Pages = bookXml.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Author> departments = new List<Author>();

            var jsonAuthors = JsonConvert.DeserializeObject<IEnumerable<AuthorsJsonModel>>(jsonString);

            foreach (var jsonAuthor in jsonAuthors)
            {
                var isEmailExist = context.Authors.Any(e => e.Email == jsonAuthor.Email);

                if (!IsValid(jsonAuthor) || isEmailExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                };

                foreach (var book in jsonAuthor.Books)
                {
                    var isBookExist = context.Books.FirstOrDefault(i => i.Id == book.Id);

                    if (isBookExist == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author =author,
                        Book = isBookExist
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Authors.Add(author);
                context.SaveChanges();

                var authorFullName = author.FirstName + " " + author.LastName;
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, authorFullName, author.AuthorsBooks.Count()));

            }


            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
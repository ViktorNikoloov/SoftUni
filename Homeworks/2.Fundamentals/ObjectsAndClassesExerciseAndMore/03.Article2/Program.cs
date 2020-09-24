using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Article2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Article article = new Article(input[0], input[1], input[2]);

                articles.Add(article);
            }

            string command = Console.ReadLine();
            List<Article> ordered = new List<Article>();

            if (command == "title")
            {
               ordered = articles.OrderBy(x => x.Title).ToList();

            }
            if (command == "content")
            {
                ordered = articles.OrderBy(x => x.Content).ToList();
            }
            if (command == "author")
            {
                ordered = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in ordered)
            {
                Console.WriteLine(article.ToString());
            }
            
        }

        class Article //•	Title – a string •	Content – a string • Author – a string
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

           

            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";

            }
        }
    }
}

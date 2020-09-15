using System;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Article article = new Article(input[0], input[1], input[2]);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //: "Edit: {new content}"; "ChangeAuthor: {new author}"; "Rename: {new title}"
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commands[0] == "Edit")
                {
                    article.Edit(commands[1]);
                }
                if (commands[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(commands[1]);
                }
                if (commands[0] == "Rename")
                {
                    article.Rename(commands[1]);
                }
            }

            Console.WriteLine(article.ToString());

        }
    }

    class Article //•	Title – a string •	Content – a string •	Author – a string
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

        public void Edit(string content)
        {
            this.Content = content;

        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;

        }

        public void Rename(string title)
        {
            this.Title = title;

        }

        public override string ToString()
        {
            string newString = $"{this.Title} - {this.Content}: {this.Author}";
            return newString;
        }
    }
}

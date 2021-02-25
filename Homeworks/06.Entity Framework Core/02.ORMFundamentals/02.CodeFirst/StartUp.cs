using _02.CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CodeFirst
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            db.Categories.Add(new Category
            {
                Title = "Sport",
                News = new List<News>
                {
                    new News
                    {
                        Title = "Botev",
                        Content = "1848-1876",
                        Comments = new List<Comment>
                        {
                            new Comment{Author = "Viktor", Content = "History"},
                            new Comment{Author = "Tanya", Content =  "Correct" }
                        }
                    }
                }
            });

            db.SaveChanges();


            var news = db.News.Select(x => new
            {
                Name = x.Title,
                CategoryName = x.Category.Title
            }).ToList();

            foreach (var title in news)
            {
                Console.WriteLine(title.Name + " " + title.CategoryName);
            }

            db.Categories.Add(new Category { Title = "PublishTime" });
            db.SaveChanges();

        }
    }
}

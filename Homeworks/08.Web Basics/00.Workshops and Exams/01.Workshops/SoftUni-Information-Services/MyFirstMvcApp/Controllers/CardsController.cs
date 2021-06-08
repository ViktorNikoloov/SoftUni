using System.Linq;

using MyFirstMvcApp.Data;
using MyFirstMvcApp.Data.Models;
using MyFirstMvcApp.ViewModels;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public HttpResponse Add()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
            }

            return View();
        }


        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(string attack, string health, string description, string name, string image, string keyword)
        {

            if (Request.FormData["name"].Length < 5)
            {
                return Error("Name should be at least 5 characters long.");
            }

            db.Cards.Add(new Card
            {
                Attack = int.Parse(attack),
                Health = int.Parse(health),
                Description = description,
                Name = name,
                ImageUrl = image,
                Keyword = keyword,
            });
            db.SaveChanges();

            return Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
            }

            var cardViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Type = x.Keyword,
            }).ToList();

            return View(cardViewModel);
        }

        public HttpResponse Collection()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
            }

            return View();
        }
    }
}

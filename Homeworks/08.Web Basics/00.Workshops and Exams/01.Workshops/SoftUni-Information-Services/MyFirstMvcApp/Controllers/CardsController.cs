using MyFirstMvcApp.Data;
using MyFirstMvcApp.Data.Models;
using MyFirstMvcApp.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;
using System.Linq;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var request = Request;
            var dbContext = new ApplicationDbContext();

            dbContext.Cards.Add(new Card
            {
                Attack = int.Parse(Request.FormData["attack"]),
                Health = int.Parse(Request.FormData["health"]),
                Description = Request.FormData["description"],
                Name = Request.FormData["name"],
                ImageUrl = Request.FormData["image"],
                Keyword = Request.FormData["keyword"],
            });
            dbContext.SaveChanges();

            return Redirect("/");
        }

        public HttpResponse All()
        {
            var db = new ApplicationDbContext();
            var cardViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Type = x.Keyword,
            }).ToList();

            return View(new AllCardsViewModel { Cards = cardViewModel });
        }

        public HttpResponse Collection()
        {
            return View();
        }
    }
}

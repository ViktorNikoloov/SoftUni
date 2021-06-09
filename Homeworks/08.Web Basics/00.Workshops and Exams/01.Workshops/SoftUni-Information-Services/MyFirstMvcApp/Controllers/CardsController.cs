using System;

using MyFirstMvcApp.Services;
using MyFirstMvcApp.ViewModels.Cards;

using SIS.HTTP;
using SIS.MvcFramework;
using SIS.MvcFramework.SIS.MvcFramework.CustomAttributes;

namespace MyFirstMvcApp.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            return View();
        }


        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || (model.Name.Length < 5 ||
                model.Name.Length > 15))
            {
                return Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                return Error("The image is required!");
            }

            if (!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return Error("Image url should be valied.");
            }

            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return Error("The Keyword is required!");
            }

            if (model.Attack < 0)
            {
                return Error("Atack should be non-negative integer.");
            }

            if (model.Health < 0)
            {
                return Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) && model.Description.Length > 200)
            {
                return Error("The Description is required and its length should be at most 200 characters");
            }

            var cardId = this.cardsService.AddCard(model);
            return AddToCollection(cardId);

            //return Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            var cardViewModel = this.cardsService.GetAll();

            return View(cardViewModel);
        }

        public HttpResponse Collection()
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            var viewModel = this.cardsService.GetByUserID(GetUserId());

            return View(viewModel);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            var userId = GetUserId();
            this.cardsService.AddCardToUserCollection(userId, cardId);
            return Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }

            var userId = GetUserId();
            cardsService.RemoveCardFromUserCollection(userId, cardId);

            return Redirect("/Cards/Collection");
        }

        public HttpResponse DeleteCard(int cardId)
        {
            if (!IsUserSignIn())
            {
                return Error("You don't have permission to access this page.");
                //return Redirect("/Users/Login");
            }
            var userId = GetUserId();

            this.cardsService.DeleteCard(userId, cardId);

            return Redirect("/Cards/All");
        }
    }
}

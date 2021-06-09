using System.Collections.Generic;
using System.Linq;

using MyFirstMvcApp.Data;
using MyFirstMvcApp.Data.Models;
using MyFirstMvcApp.ViewModels.Cards;

namespace MyFirstMvcApp.Services
{
    public class CardsServices : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
            };

            db.Cards.Add(card);
            db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return db.Cards.Select(x => new CardViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Type = x.Keyword,
            }).ToList();
        }

        public IEnumerable<CardViewModel> GetByUserID(string userId)
        {
            return db.UserCards
                 .Where(x => x.UserId == userId)
                 .Select(x => new CardViewModel
                 {
                     Id = x.CardId,
                     Attack = x.Card.Attack,
                     Health = x.Card.Health,
                     Description = x.Card.Description,
                     ImageUrl = x.Card.ImageUrl,
                     Name = x.Card.Name,
                     Type = x.Card.Keyword,
                 })
                 .ToList();
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (db.UserCards.Any(x => x.CardId == cardId && x.UserId == userId))
            {
                return;
            }

            db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });

            db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            db.UserCards.Remove(userCard);
            db.SaveChanges();
        }

        public void DeleteCard(string userId, int cardId)
        {
            var card = db.Cards.FirstOrDefault(x => x.Id == cardId);

            RemoveCardFromUserCollection(userId, cardId);
            db.Cards.Remove(card);

            db.SaveChanges();
        }
    }
}

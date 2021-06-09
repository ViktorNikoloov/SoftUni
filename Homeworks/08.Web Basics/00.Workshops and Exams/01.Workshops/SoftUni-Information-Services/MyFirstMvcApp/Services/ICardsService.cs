using System.Collections.Generic;

using MyFirstMvcApp.ViewModels.Cards;

namespace MyFirstMvcApp.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardInputModel input);

        IEnumerable<CardViewModel> GetAll();

        IEnumerable<CardViewModel> GetByUserID(string userId);

        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromUserCollection(string userId, int cardId);

        void DeleteCard(string userId, int cardId);
    }
}

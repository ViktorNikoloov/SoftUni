using MyFirstMvcApp.Data;

namespace MyFirstMvcApp.Services
{
    public class CardsServices : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard()
        {
            throw new System.NotImplementedException();
        }
    }
}

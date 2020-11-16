namespace Animals.Models.Contracts
{
    public interface IAnimal
    {
        public string Name { get;}

        public string FavouriteFood { get;}

        public string ExplainSelf();
    }
}

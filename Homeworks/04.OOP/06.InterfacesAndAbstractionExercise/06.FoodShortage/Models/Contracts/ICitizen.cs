namespace _06.FoodShortage.Models.Contracts
{
    internal interface ICitizen : IBuyer
    {
        public string Name { get; }

        public int Age { get; }

    }
}

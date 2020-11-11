namespace _04.BorderControl.Models.Contracts
{
    interface ICitizen : IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }

    }
}

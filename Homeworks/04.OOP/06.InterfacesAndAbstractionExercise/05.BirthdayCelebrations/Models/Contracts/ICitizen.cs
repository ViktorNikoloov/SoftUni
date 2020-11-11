namespace _05.BirthdayCelebrations.Models.Contracts
{
    internal interface ICitizen : IIdentifiable, IBirthable
    {
        public string Name { get; }

        public int Age { get; }

    }
}

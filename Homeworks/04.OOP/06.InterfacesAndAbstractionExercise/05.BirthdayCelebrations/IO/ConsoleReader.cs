namespace _05.BirthdayCelebrations.IO.Contracts
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => System.Console.ReadLine();
    }
}

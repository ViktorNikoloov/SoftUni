namespace _04.BorderControl.IO.Contracts
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        => System.Console.ReadLine();
    }
}

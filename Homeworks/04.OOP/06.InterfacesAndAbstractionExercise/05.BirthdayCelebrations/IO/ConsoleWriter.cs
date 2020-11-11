namespace _05.BirthdayCelebrations.IO.Contracts
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        =>System.Console.Write(text);

        public void WriteLine(string text)
        =>System.Console.WriteLine(text);
    }
}

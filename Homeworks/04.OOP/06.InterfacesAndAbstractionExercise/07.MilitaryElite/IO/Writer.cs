using _07.MilitaryElite.IO.Contracts;

namespace _07.MilitaryElite.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        => System.Console.Write(text);

        public void WriteLine(string text)
        => System.Console.WriteLine(text);
    }
}

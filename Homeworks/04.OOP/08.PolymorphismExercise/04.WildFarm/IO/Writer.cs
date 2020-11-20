using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        => System.Console.Write(text);

        public void WriteLine(string text)
        => System.Console.WriteLine(text);

    }
}

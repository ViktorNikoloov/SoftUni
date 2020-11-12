using _06.FoodShortage.IO.Contracts;

namespace _06.FoodShortage.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        => System.Console.Write(text);

        public void WriteLine(string text)
        => System.Console.WriteLine(text);
    }
}

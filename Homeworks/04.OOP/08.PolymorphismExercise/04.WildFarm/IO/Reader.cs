using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        => System.Console.ReadLine();
    }
}

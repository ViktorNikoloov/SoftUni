using _06.FoodShortage.IO;
using _06.FoodShortage.IO.Contracts;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

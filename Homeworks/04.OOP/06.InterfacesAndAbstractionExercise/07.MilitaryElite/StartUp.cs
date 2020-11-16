using _07.MilitaryElite.Core;
using _07.MilitaryElite.IO;
using _07.MilitaryElite.IO.Contracts;

namespace _07.MilitaryElite
{
    public class StartUp
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

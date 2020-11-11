using _04.BorderControl.Core;
using _05.BirthdayCelebrations.IO.Contracts;

namespace _05.BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

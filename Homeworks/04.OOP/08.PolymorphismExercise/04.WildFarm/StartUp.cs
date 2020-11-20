using _04.WildFarm.IO;
using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm
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

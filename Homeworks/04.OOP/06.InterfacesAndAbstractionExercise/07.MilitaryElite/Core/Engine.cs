using _07.MilitaryElite.IO.Contracts;

namespace _07.MilitaryElite.Core
{
    class Engine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

        }
    }
}

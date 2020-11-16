using _07.MilitaryElite.Models.Contracts;

namespace _07.MilitaryElite.IO.Contracts
{
    public interface IWriter
    {
        public void Write(string text);

        public void WriteLine(string text);
        
    }
}

using _06.FoodShortage.IO.Contracts;

namespace _06.FoodShortage.IO
    
{
    public class Reader : IReader
    {
        public string ReadLine()
        => System.Console.ReadLine();
        
    }
}

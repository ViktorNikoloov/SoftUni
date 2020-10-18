using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> intInput = new EqualityScale<int>(5, 5);
            Console.WriteLine(intInput.AreEqual());


            EqualityScale<string> strInput = new EqualityScale<string>("ASD", "ASS");
            Console.WriteLine(strInput.AreEqual());

        }
    }
}

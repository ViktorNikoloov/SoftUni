using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            StringRandomizer output = new StringRandomizer();
            output.input = Console.ReadLine().Split().ToList();
            output.Randomize();
            output.PrintRandomize();

        }
    }
    public class StringRandomizer
    {
        public List<string> input;

        public void Randomize()
        {
            Random rand = new Random();

            for (int i = 0; i < input.Count; i++)
            {
                int newRand = rand.Next(0, input.Count);
                string temp = input[i];
                input[i] = input[newRand];
                input[newRand] = temp;

            }


        }

        public void PrintRandomize()
        {
            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }

}

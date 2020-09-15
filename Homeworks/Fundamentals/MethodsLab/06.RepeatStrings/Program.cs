using System;
using System.Text;

namespace _06.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatStringFast(name, count));

        }

        static string RepeatString(string name, int count)
        {
            string massege = "";

            for (int i = 0; i < count; i++)
            {
                massege += name;
            }

            return massege;
        }

        static string RepeatStringFast(string name, int count)
        {
            StringBuilder massege= new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                massege.Append(name);
            }

            return massege.ToString();
        }
    }
}

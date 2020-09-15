using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Console.WriteLine(FindTheNumberOfTheVowels(name));
        }

        static int FindTheNumberOfTheVowels(string name)
        {
            int count = 0;

            for (int i = 0; i < name.Length; i++)
            {
                //A, E, I, O, U,(Y)
                //int digit = name[i];

                switch (name[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        count++;
                        break;
                }
            }
            return count;
        }
    }
}

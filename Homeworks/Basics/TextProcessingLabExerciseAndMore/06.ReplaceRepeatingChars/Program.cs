using System;
using System.Text;


namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            

            for (int i = 0; i < text.Length; i++)
            {
                if (i ==text.Length -1)
                {
                    break;
                }

                if (text[i] == text[i+1])//aaadfdggg
                {
                    int index = i + 1;
                    text.Remove(i+1, 1);
                    i--;
                    
                }
            }

            Console.WriteLine(text);
        }
    }
}

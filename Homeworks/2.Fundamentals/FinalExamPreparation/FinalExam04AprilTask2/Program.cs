using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace FinalExam04AprilTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection emojies = Regex.Matches(input, @"([::|**]){2}([A-Z][a-z]{2,})\1{2}");
            MatchCollection digits = Regex.Matches(input, @"\d+");
            List<string> coolEmojies = new List<string>();
            BigInteger threshold = 1;
            string strNum = "";

            foreach (var item in digits)
            {
                strNum += item;
            }
            for (int i = 0; i < strNum.Length; i++)
            {
                threshold *= BigInteger.Parse(strNum[i].ToString());
            }
            
            for (int i = 0; i < emojies.Count; i++)
            {
                int result = 0;
                string curremoji = emojies[i].Groups[2].Value;

                for (int g = 0; g < curremoji.Length; g++)
                {
                    result += curremoji[g];
                }

                if (result > threshold)
                {
                    coolEmojies.Add(emojies[i].Value);
                }
            }

            

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine(@$"{emojies.Count} emojis found in the text. The cool ones are: 
{string.Join(Environment.NewLine, coolEmojies)}");

        }
    }
}

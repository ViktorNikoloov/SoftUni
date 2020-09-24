using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isFromSixToTenCharacters = false;
            bool isConsistsOnlyLettersAndDigits = false;
            bool haveItAtLeastTwoDifits = false;

            if (6 <= LengthOfTheString(password) && LengthOfTheString(password) <= 10)
            {
                isFromSixToTenCharacters = true;
            }
            if (IsStringConsistOnlyLettersAndDigits(password) == true)
            {
                isConsistsOnlyLettersAndDigits = true;
            }
            if (NumberOfTheNumbersInThrString(password) >= 2)
            {
                haveItAtLeastTwoDifits = true;
            }

            if (isFromSixToTenCharacters && isConsistsOnlyLettersAndDigits && haveItAtLeastTwoDifits)
            {
                Console.WriteLine("Password is valid");
            }
            if (isFromSixToTenCharacters == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (isConsistsOnlyLettersAndDigits == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (haveItAtLeastTwoDifits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

        }

        static int LengthOfTheString(string input)
        {
            int length = input.Length;
            return length;
        }
        static int NumberOfTheNumbersInThrString(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (48 <= input[i] && input[i] <= 57)
                {
                    count++;
                }
            }
            return count;
        }

        static bool IsStringConsistOnlyLettersAndDigits(string input)
        {
            bool isOnlyLetters = true;
            for (int i = 0; i < input.Length; i++)
            {
                if ((65 > input[i] || input[i] > 90) && (97 > input[i] || input[i] > 122) && (48 > input[i] || input[i] > 57))
                {
                    isOnlyLetters = false;
                }
            }
            return isOnlyLetters;
        }
    }
}

namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrWhiteSpace(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;
            }

            var stack = new Stack<char>(parentheses.Length / 2);

            foreach (var currentCharacter in parentheses)
            {
                char expectedCharacter = default;

                switch (currentCharacter)
                {
                    case ')':
                        expectedCharacter = '(';
                        break;
                    case ']':
                        expectedCharacter = '[';
                        break;
                    case '}':
                        expectedCharacter = '{';
                        break;
                    default:
                        stack.Push(currentCharacter);
                        break;
                }

                if (expectedCharacter == default)
                {
                    continue;
                }

                if (stack.Pop() != expectedCharacter)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}

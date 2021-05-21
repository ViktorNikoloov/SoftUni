using System;

namespace SIS.HTTP
{
    public class Header
    {
        public Header(string headerLine)
        {
            var headerParts = headerLine
                .Split(": ", 2, StringSplitOptions.None);

            Name = headerParts[0];
            Value = headerParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }
}
﻿namespace SIS.HTTP
{
    public class Cookie
    {
        public Cookie(string cookieAsString)
        {
            var cookieParts = cookieAsString.Split('=', 2);

            Name = cookieParts[0];
            Value = cookieParts[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
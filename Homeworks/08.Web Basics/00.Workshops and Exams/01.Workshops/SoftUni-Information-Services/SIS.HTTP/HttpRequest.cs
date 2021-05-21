using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            var lines = requestString
                .Split(HttpConstants.NewLine, StringSplitOptions.None);

            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(' ');

            Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);
            Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;
            StringBuilder bodyBuilder = new StringBuilder();
            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }

            if (Headers.Any(x=>x.Name == HttpConstants.RequestCookieHeader))
            {
                var cookiesAsString = Headers
                    .FirstOrDefault(x=>x.Name == HttpConstants.RequestCookieHeader).Value;
                var cookies = cookiesAsString.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookieAsSring in cookies)
                {
                    Cookies.Add(new Cookie(cookieAsSring));
                }
            }

            Body = bodyBuilder.ToString();
            
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}


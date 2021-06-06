using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using SIS.HTTP.Enums;

namespace SIS.HTTP
{
    public class HttpRequest
    {
        public static IDictionary<string, Dictionary<string, string>> Sessions =
            new Dictionary<string, Dictionary<string, string>>();

        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();
            FormData = new Dictionary<string, string>();

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

            if (Headers.Any(x => x.Name == HttpConstants.RequestCookieHeader))
            {
                var cookiesAsString = Headers
                    .FirstOrDefault(x => x.Name == HttpConstants.RequestCookieHeader).Value;
                var cookies = cookiesAsString.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookieAsSring in cookies)
                {
                    Cookies.Add(new Cookie(cookieAsSring));
                }
            }

            var sessionCookie = Cookies.FirstOrDefault(x => x.Name == HttpConstants.SessionCookieName);
            if (sessionCookie == null)
            {
                var sessionId = Guid.NewGuid().ToString();
                Session = new Dictionary<string, string>();

                Sessions.Add(sessionId, Session);
                Cookies.Add(new Cookie(HttpConstants.SessionCookieName, sessionId));
            }
            else if (!Sessions.ContainsKey(sessionCookie.Value))
            {
                Session = new Dictionary<string, string>();
                Sessions.Add(sessionCookie.Value, Session);
            }
            else
            {
                Session = Sessions[sessionCookie.Value];
            }

            Body = bodyBuilder.ToString().TrimEnd();
            var parameters = Body.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var parameter in parameters)
            {
                var parameterParts = parameter.Split('=', 2);
                var name = parameterParts[0];
                var value = WebUtility.UrlDecode(parameterParts[1]);
                //var value = parameterParts[1];

                if (!FormData.ContainsKey(name))
                {
                    FormData.Add(name, value);
                }
            }

        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public IDictionary<string, string> FormData { get; set; }

        public Dictionary<string, string> Session { get; set; }

        public string Body { get; set; }
    }
}


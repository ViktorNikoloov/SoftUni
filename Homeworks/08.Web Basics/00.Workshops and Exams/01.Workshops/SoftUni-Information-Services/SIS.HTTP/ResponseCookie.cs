using System.Text;

namespace SIS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) 
            : base(name, value)
        {
            Path = "/";
        }

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder cookieBuilder = new StringBuilder();
            cookieBuilder.Append($"{Name}={Value}; Path={Path};");

            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={MaxAge};");
            }

            if(HttpOnly)
            {
                cookieBuilder.Append(" HttpOnly;");
            }

            return cookieBuilder.ToString();
        }

        //Domain

        //Secure
    }
}

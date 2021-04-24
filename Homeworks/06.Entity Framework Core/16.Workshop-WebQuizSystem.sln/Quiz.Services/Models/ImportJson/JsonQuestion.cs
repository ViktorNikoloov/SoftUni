using System.Collections.Generic;

namespace Quiz.Services.ImportJson
{
    public class JsonQuestion
    {
        public string Question { get; set; }
        public IEnumerable<JsonAnswer> Answers { get; set; }
    }
}

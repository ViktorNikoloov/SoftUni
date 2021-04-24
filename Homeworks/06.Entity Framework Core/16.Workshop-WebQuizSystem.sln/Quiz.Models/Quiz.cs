using System.Collections.Generic;

namespace Quiz.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}

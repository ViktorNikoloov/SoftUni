using System.Collections.Generic;

namespace Quiz.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

    }
}
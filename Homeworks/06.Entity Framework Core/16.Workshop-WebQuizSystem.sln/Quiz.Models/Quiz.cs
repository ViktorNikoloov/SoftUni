using System.Collections.Generic;

namespace Quiz.Models
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }

    }
}

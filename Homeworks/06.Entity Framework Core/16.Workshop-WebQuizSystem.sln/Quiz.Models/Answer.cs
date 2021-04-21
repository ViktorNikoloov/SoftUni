using System.Collections.Generic;

namespace Quiz.Models
{
    public class Answer
    {
        public Answer()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCorrect { get; set; }

        public int Points { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }

    }
}
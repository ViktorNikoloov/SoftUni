namespace Quiz.Models
{
    public class UserAnswer
    {
        public int UserId { get; set; }

        public int QuizId { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}

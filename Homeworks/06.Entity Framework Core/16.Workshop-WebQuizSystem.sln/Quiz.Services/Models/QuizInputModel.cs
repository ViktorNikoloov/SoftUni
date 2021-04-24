using System.Collections.Generic;

namespace Quiz.Services.Models
{
    public class QuizInputModel
    {
        public string UserId { get; set; }

        public int QuizId { get; set; }

        public virtual List<QuestionInputModel> Quiestions { get; set; }
    }
}

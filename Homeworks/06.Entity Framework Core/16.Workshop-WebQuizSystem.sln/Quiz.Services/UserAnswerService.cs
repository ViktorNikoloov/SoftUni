using System.Collections.Generic;
using System.Linq;

using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAnswerService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddUserAnswer(string userName, int questionId, int answerId)
        {
            var userId = applicationDbContext
                .Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var userAnswer = applicationDbContext
                .UserAnswers
                .FirstOrDefault(x => x.IdentityUserId == userId && x.QuestionId == questionId);
            userAnswer.AnswerId = answerId;
           
            applicationDbContext.SaveChanges();
        }

        public void BulkAddUserAnswer(QuizInputModel quizInputModel)
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var item in quizInputModel.Quiestions)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInputModel.UserId,
                    AnswerId = item.AnswerId,
                    QuestionId = item.QuestionId
                };

                userAnswers.Add(userAnswer);
            }

            applicationDbContext.UserAnswers.AddRange(userAnswers);
            applicationDbContext.SaveChanges();
        }

        public int GetUserResult(string userName, int quizId)
        {
            var userId = applicationDbContext
                .Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();
            var totalPoints = applicationDbContext
                .UserAnswers
                .Where(x => x.IdentityUserId == userId && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);

            return totalPoints;

            //var totalPoints = applicationDbContext
            //    .Quizzes
            //    .Include(q => q.Questions)
            //    .ThenInclude(a => a.Answers)
            //    .ThenInclude(ua => ua.UserAnswers)
            //    .Where(x => x.Id == quizId && x.UserAnswers.Any(x => x.IdentityUserId == userId))
            //    .SelectMany(x => x.UserAnswers)
            //    .Where(x => x.Answer.IsCorrect)
            //    .Sum(x => x.Answer.Points);

            //var userAnswers = applicationDbContext
            //    .UserAnswers
            //    .Where(x => x.IdentityUserId == userId && x.QuizId == quizId)
            //    .ToList();

            //int? totalPoints = 0;
            //foreach (var userAnswer in userAnswers)
            //{
            //    totalPoints += originalQuiz
            //        .Questions
            //        .FirstOrDefault(x => x.Id == userAnswer.QuestionId)
            //        .Answers
            //        .Where(x=>x.IsCorrect)
            //        .FirstOrDefault(x => x.Id == userAnswer.AnswerId)
            //        ?.Points;
            //} 

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserAnswerService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void AddUserAnswer(string userId, int answerId)
        {
            var userAnswer = new UserAnswer()
            {
                IdentityUserId = userId,
                AnswerId = answerId,

            };

            applicationDbContext.UserAnswers.Add(userAnswer);
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

        public int GetUserResult(string userId, int quizId)
        {
            var totalPoints = applicationDbContext
                .UserAnswers
                .Where(x => x.IdentityUserId == userId && x.QuestionId == quizId)
                .Sum(x => x.Answer.Points);


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

            return totalPoints;
        }
    }
}

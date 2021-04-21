﻿using Quiz.Data;
using Quiz.Models;

namespace Quiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public QuestionService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int Add(string title, int quizId)
        {
            var question = new Question
            {
                Title = title,
                QuizId = quizId
            };

            applicationDbContext.Questions.Add(question);
            applicationDbContext.SaveChanges();

            return question.Id;
        }
    }
}

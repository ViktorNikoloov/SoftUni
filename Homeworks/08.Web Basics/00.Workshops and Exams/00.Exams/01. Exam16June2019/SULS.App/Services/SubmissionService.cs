using System;
using System.Linq;

using SULS.App.Data;
using SULS.App.Models;
using SULS.App.ViewModels.Submissions;

namespace SULS.App.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SulsDbContext db;
        private readonly Random random;

        public SubmissionService(SulsDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxpoints = db
                .Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            db.Submissions
                .Add(new Submission
                {
                    ProblemId = problemId,
                    UserId = userId,
                    Code = code,
                    CreatedOn = DateTime.UtcNow,
                    AchievedResult = random.Next(0, problemMaxpoints + 1),
                });

            db.SaveChanges(); 
        }
    }
}

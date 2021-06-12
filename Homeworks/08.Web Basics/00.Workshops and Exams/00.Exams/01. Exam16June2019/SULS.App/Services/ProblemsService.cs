using System.Collections.Generic;
using System.Linq;

using SULS.App.Data;
using SULS.App.Models;
using SULS.App.ViewModels.Problems;

namespace SULS.App.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SulsDbContext db;

        public ProblemsService(SulsDbContext db)
        {
            this.db = db;
        }

        public void AddProblem(string name, int points)
        {
            db.Problems.Add(new Problem
            {
                Name = name,
                Points = points,
            });

            db.SaveChanges();
        }


        public IEnumerable<HomePageProblemViewModel> GetAllProblems()
        => db.Problems
            .Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count,
            }).ToList();



        public string GetNameById(string id)
        => db.Problems
            .Where(x => x.Id == id)
            .Select(x => x.Name)
            .FirstOrDefault();

        public ProblemViewModel GetById(string id)
        {
            return db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn.ToShortDateString(),
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }

        public bool IsProblemExist(string name)
            => db.Problems.Any(x => x.Name == name);
    }
}


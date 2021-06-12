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

        //public IEnumerable<HomePageProblemViewModel> GetAllSubmissions()
        //=> db.Users
        //    .Select(x => new DetailsInputModel
        //    {
        //        Username = x.Username,

        //        AchievedResult = x.Submissions.Select(s=>s.AchievedResult)
        //    }).ToList();

        public string GetNameById(string id)
        => db.Problems
            .Where(x => x.Id == id)
            .Select(x=>x.Name)
            .FirstOrDefault();

        public bool IsProblemExist(string name)
        => db.Problems.Any(x => x.Name == name);

    }
}

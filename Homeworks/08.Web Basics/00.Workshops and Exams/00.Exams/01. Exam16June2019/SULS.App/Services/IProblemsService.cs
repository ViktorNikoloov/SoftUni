using System.Collections.Generic;

using SULS.App.ViewModels.Problems;

namespace SULS.App.Services
{
    public interface IProblemsService
    {
        void AddProblem(string name, int points);

        bool IsProblemExist(string name);

        string GetNameById(string id);

        IEnumerable<HomePageProblemViewModel> GetAllProblems();

        DetailsInputModel GetById(string id);
    }
}

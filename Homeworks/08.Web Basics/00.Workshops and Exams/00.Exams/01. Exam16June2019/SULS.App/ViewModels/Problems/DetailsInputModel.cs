using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class DetailsInputModel
    {
        public string ProblemName { get; set; }

        public IEnumerable<ProblemInfoModel> ProblemInfo { get; set; }
    }
}

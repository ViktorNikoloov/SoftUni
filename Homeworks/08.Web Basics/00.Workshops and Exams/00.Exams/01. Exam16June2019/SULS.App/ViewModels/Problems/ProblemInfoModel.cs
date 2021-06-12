using System;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemInfoModel
    {
        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public string CreatedOn { get; set; }

        public string SubmissionId { get; set; }
    }
}
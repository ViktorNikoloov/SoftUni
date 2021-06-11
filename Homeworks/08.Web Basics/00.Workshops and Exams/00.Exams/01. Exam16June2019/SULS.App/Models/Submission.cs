using System;
using System.ComponentModel.DataAnnotations;

namespace SULS.App.Models
{
    public class Submission
    {
        public Submission()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Range(0, 300)]
        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Problem Problem { get; set; }

        public virtual User User { get; set; }
    }
}

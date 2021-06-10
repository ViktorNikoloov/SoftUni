using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.App.Models
{
    public class Problem
    {
        public Problem()
        {
            Id = Guid.NewGuid().ToString();
            Submissions = new HashSet<Submission>();

        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(50, 300)]
        public int Points { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

namespace Git.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Repository
    {
        public Repository()
        {
            Id = Guid.NewGuid().ToString();
            Commits = new HashSet<Commit>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}

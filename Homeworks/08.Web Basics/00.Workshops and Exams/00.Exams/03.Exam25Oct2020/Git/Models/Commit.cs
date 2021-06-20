namespace Git.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public string RepositoryId { get; set; }
        public virtual Repository Repository { get; set; }

    }
}

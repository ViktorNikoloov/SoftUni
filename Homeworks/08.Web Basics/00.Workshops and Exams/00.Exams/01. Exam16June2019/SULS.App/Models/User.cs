using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.App.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Submissions = new HashSet<Submission>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}

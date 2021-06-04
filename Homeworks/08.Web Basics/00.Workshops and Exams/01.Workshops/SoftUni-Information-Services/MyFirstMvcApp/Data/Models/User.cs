using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace MyFirstMvcApp.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Cards = new HashSet<UserCard>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}

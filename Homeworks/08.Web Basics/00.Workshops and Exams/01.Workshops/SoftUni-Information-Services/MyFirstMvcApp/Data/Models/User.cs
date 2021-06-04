using System;
using System.Collections.Generic;

using SIS.MvcFramework;

namespace MyFirstMvcApp.Data.Models
{
    public class User : UserIdentity
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Cards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}

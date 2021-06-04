﻿using System.ComponentModel.DataAnnotations;

namespace SIS.MvcFramework
{
    public class UserIdentity
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

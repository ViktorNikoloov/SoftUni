﻿namespace MusicHub.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        public Producer()
        {
            Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}

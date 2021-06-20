using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid().ToString();
            Issues = new HashSet<Issue>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}

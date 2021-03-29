using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            Purchases =new HashSet<Purchase>();
            GameTags = new HashSet<GameTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue)]
        public decimal Price { get; set; } 

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }


        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<GameTag> GameTags { get; set; } //TODO: Each game must have at least one tag.
    }
}

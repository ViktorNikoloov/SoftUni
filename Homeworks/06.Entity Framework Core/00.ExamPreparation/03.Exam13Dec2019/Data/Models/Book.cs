using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using BookShop.Data.Models.Enums;

namespace BookShop.Data.Models
{
    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)] //TODO: Min:3
        public string Name  { get; set; }

        public Genre Genre { get; set; }

        //TODO:[Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price  { get; set; }

        //TODO:[Range(50, 5000)]
        public int Pages { get; set; }

        public DateTime PublishedOn  { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}

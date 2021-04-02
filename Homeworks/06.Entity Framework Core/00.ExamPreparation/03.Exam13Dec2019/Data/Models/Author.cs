using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)] //TODO: Min:3
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)] //TODO: Min:3
        public string LastName { get; set; }

        [Required]
        //TODO:[EmailAddress]
        public string Email { get; set; }

        [Required] //TODO: Regex
        public string Phone { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}

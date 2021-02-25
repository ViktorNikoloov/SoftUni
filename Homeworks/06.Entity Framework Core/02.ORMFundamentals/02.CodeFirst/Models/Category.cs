using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02.CodeFirst.Models
{
    public class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}

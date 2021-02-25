using System.ComponentModel.DataAnnotations;

namespace _02.CodeFirst.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }

        [MaxLength(50)]
        public string Author { get; set; }
        
        public string Content { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace _04.EfCodeFirstDemo.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }
    }
}

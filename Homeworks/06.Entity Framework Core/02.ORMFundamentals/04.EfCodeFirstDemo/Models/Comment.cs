using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace _04.EfCodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "IX_QuestionId")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

       //public ICollection<Question> Questions { get; set; }
    }
}

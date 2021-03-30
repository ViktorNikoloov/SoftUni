using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserJsonModel
    {
        [Required]
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(minimum: 3, maximum: 103)]
        public int Age { get; set; }

        [MinLength(1)]
        public CardModel[] Cards { get; set; }


    }
}

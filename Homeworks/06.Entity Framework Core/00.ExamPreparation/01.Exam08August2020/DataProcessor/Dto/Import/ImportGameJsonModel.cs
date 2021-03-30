using System;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameJsonModel
    {
        [Required]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(1)]
        public string[] Tags { get; set; }


    }
}

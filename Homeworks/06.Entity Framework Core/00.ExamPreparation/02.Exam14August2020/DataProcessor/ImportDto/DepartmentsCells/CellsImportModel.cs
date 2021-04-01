using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto.DepartmentsCells
{
   public  class CellsImportModel
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }
    }
}

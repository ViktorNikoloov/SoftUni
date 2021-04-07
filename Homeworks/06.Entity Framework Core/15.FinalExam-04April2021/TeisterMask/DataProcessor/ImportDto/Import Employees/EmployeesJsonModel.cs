using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto.Import_Employees
{
    public class EmployeesJsonModel
    {
        [Required]
        [RegularExpression(@"[\w]{3,40}")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}

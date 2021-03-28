using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }


        public virtual ICollection<Visitation> Visitations { get; set; }

    }
}

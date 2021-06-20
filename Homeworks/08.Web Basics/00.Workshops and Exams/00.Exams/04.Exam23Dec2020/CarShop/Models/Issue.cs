using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Issue
    {
        public Issue()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        public string CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}

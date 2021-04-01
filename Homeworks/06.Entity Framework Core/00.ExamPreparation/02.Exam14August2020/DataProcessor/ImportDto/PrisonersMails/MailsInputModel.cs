﻿using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto.PrisonersMails
{
    public class MailsInputModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(@"^([A-z0-9\s]+ str.)$")]
        public string Address { get; set; }
    }
}
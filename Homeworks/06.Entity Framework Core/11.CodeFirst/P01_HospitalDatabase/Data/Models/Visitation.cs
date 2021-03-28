﻿using System;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        //TODO: Is it default required
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace _01.DatabaseFirst.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}

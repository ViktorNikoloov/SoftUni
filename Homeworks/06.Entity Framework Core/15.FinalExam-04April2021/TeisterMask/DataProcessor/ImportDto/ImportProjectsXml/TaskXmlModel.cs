using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto.ImportProjectsXml
{
    [XmlType("Task")]
    public class TaskXmlModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Range(0, 3)]
        public int ExecutionType { get; set; }

        [Range(0, 4)]
        public int LabelType { get; set; }
    }
}

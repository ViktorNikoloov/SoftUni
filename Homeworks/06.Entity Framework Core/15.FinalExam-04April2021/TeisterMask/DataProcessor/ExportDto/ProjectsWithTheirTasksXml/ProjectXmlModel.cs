using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto.ProjectsWithTheirTasksXml
{
    [XmlType("Project")]
    public class ProjectXmlModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlAnyElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlAnyElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public TaskXmlModel[] Tasks { get; set; }
    }
}

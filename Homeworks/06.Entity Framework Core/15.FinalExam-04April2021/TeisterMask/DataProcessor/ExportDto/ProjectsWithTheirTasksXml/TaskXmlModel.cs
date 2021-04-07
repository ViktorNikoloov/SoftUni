using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto.ProjectsWithTheirTasksXml
{
    [XmlType("Task")]
    public class TaskXmlModel
    {
        [XmlAnyElement("Name")]
        public string Name { get; set; }

        [XmlAnyElement("Label")]
        public string Label { get; set; }
    }
}

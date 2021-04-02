namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto.InboxPrisoner;
    using SoftJail.DataProcessor.ExportDto.PrisonersWithCellsAndOfficers;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var allPrisonersCellsAndOfficerByIds = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new PrisonersWithCellsXmlModel()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(o => new PrisonersOfficersXmlModel()
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal
                        .Parse(p.PrisonerOfficers.Sum(o => o.Officer.Salary)
                        .ToString("F2"))
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var jsonResult = JsonConvert.SerializeObject(allPrisonersCellsAndOfficerByIds, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            const string root = "Prisoners";

            var namesOfPrisoners = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var inboxPrisoners = context
                .Prisoners
                .Where(p => namesOfPrisoners.Contains(p.FullName))
                .Select(p => new PrisonerXmlModel()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new EncryptedMessagesXmlModel()
                    {
                        //Description = Reverse(m.Description)
                        Description = string.Join("", m.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var textWriter = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PrisonerXmlModel[]), new XmlRootAttribute(root));
            xmlSerializer.Serialize(textWriter, inboxPrisoners, nameSpace);

            return textWriter.ToString().TrimEnd();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
using BranchProductApp.Core.Branches;
using System.Xml;

namespace BranchProductApp.Core.Parsers;

public static class XmlParser
{
    public static List<Branch> DeserializeXmlToList(string filePath)
    {
        var branches = new List<Branch>();

        var xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        var branchNodes = xmlDoc.SelectNodes("//Branch");

        if (branchNodes != null)
        {
            foreach (XmlNode branchNode in branchNodes)
            {
                var branch = new Branch
                {
                    Id = int.Parse(branchNode.Attributes["ID"]?.Value),
                    Name = branchNode.Attributes["Name"]?.Value,
                    TelephoneNumber = branchNode.Attributes["TelephoneNumber"]?.Value
                };

                var openDateString = branchNode.Attributes["OpenDate"]?.Value;
                if (DateTime.TryParseExact(openDateString, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out var parsedDate))
                {
                    branch.OpenDate = parsedDate;
                }

                branches.Add(branch);
            }
        }

        return branches;
    }
}

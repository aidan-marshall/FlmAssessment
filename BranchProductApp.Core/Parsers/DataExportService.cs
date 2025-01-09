using BranchProductApp.Core.Branches;
using CsvHelper;
using System.Globalization;
using System.Text.Json;
using System.Xml.Serialization;

namespace BranchProductApp.Core.Parsers;

public static class DataExportService
{
    public static void ExportToCsv<T>(IEnumerable<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }

    public static void ExportToJson<T>(IEnumerable<T> records, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(records, options);
        File.WriteAllText(filePath, json);
    }

    public static void ExportToXml<T>(IEnumerable<T> records, string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, records.ToList());
        }
    }

    public static BranchExportDto MapBranchToDto(Branch branch)
    {
        return new BranchExportDto
        {
            Id = branch.Id,
            Name = branch.Name,
            TelephoneNumber = branch.TelephoneNumber ?? "N/A",
            OpenDate = branch.OpenDate.HasValue ? branch.OpenDate.Value.ToString("yyyy-MM-dd") : "N/A"
        };
    }

    public static List<BranchExportDto> MapBranchesToDtos(IEnumerable<Branch> branches)
    {
        return branches.Select(MapBranchToDto).ToList();
    }
}

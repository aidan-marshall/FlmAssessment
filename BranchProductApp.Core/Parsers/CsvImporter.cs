using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace BranchProductApp.Core.Parsers;

public static class CsvImporter
{
    public static List<T> ParseCsv<T>(string filePath, ClassMap<T> classMap)
    {
        var records = new List<T>();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap(classMap);
            records = csv.GetRecords<T>().ToList();
        }
        return records;
    }
}

using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using System.Globalization;


namespace BranchProductApp.Core.Parsers.Converters
{
    public class CustomDateTimeConverter : DateTimeConverter
    {
        public override object? ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            return DateTime.TryParseExact(text, "yyyy/MM/dd", null, DateTimeStyles.None, out var parsedDate) ? parsedDate : null;
        }
    }
}

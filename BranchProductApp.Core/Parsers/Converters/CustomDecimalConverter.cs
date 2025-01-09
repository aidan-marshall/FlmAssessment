using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;

namespace BranchProductApp.Core.Parsers.Converters;
public class CustomDecimalConverter : ITypeConverter
{
    public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        return null;
    }

    public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        return value.ToString();
    }
}

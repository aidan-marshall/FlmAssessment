using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace BranchProductApp.Core.Parsers.Converters
{
    public class YesNoBooleanConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return text.ToUpper() == "Y";
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ((bool)value) ? "Y" : "N";
        }
    }
}

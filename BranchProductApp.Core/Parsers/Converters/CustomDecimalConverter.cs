using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchProductApp.Core.Parsers.Converters;
public class CustomDecimalConverter : ITypeConverter
{
    public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (text == "-")
        {
            return null;
        }

        if (decimal.TryParse(text, out var result))
        {
            return result;
        }

        return null;
    }

    public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value == null)
        {
            return "-";
        }

        return value.ToString();
    }
}

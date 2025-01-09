using System.Text.RegularExpressions;

namespace BranchProductApp.WinForms.Helpers
{
    internal class Helpers
    {
        internal static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regex to ensure the telephone number contains only digits (allowing spaces, dashes, or parentheses for formatting)
            var phoneRegex = new Regex(@"^\+?(\d[\d\- ]{7,}\d$)");
            return phoneRegex.IsMatch(phoneNumber);
        }
    }
}

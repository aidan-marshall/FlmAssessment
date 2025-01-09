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

        internal static DialogResult ConfirmAction(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        internal static DialogResult Confirm(string action, string entity)
        {
            return ConfirmAction($"Are you sure you want to {action} this {entity}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}

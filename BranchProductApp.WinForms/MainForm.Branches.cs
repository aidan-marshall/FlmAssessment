using BranchProductApp.Core.Parsers;
using System.Text;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async void BranchesImportButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var filePath = openFileDialog.FileName;
            var fileExtension = Path.GetExtension(filePath).ToLower();

            try
            {
                var branches = fileExtension switch
                {
                    ".csv" => CsvParser.ParseCsv(filePath) ,
                    ".json" => JsonParser.ParseJson(filePath),
                    ".xml" => XmlParser.DeserializeXmlToList(filePath),
                    _ => throw new NotSupportedException("File format not supported")
                };

                await branchService.AddBranches(branches);
                await LoadBranches();
                MessageBox.Show("Data imported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing data: {ex.Message}");
            }
        }
        private void BranchesExportButton_Click(object sender, EventArgs e)
        {

        }
    }
}

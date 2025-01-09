using BranchProductApp.Core.Branches;
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
                    ".csv" => CsvImporter.ParseCsv(filePath) ,
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
        private async void BranchesExportButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Branches Export";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = saveFileDialog.FileName;
                    var branches = await branchService.GetBranches();

                    if (selectedFilePath.EndsWith(".csv"))
                    {
                        DataExportService.ExportToCsv(branches, selectedFilePath);
                    }
                    else if (selectedFilePath.EndsWith(".json"))
                    {
                        DataExportService.ExportToJson(branches, selectedFilePath);
                    }
                    else if (selectedFilePath.EndsWith(".xml"))
                    {
                        DataExportService.ExportToXml(branches, selectedFilePath);
                    }

                    MessageBox.Show("Branches data has been successfully exported.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

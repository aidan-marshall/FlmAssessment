using BranchProductApp.Core.Parsers;
using Microsoft.Extensions.Logging;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async void ProductsImportButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var filePath = openFileDialog.FileName;
            var fileExtension = Path.GetExtension(filePath).ToLower();

            try
            {
                var products = fileExtension switch
                {
                    ".csv" => CsvImporter.ParseCsvForProducts(filePath),
                    ".json" => JsonParser.ParseProductsJson(filePath),
                    ".xml" => throw new NotImplementedException(),
                    _ => throw new NotSupportedException("File format not supported")
                };

                await productService.AddProducts(products);
                await LoadProducts();
                MessageBox.Show("Data imported successfully!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error importing data from file: {FilePath}", filePath);
                MessageBox.Show($"Error importing data: {ex.Message}");
            }
        }

        private async void ProductExportButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Products Export";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = saveFileDialog.FileName;
                    var products = await productService.GetProducts();

                    try
                    {
                        if (selectedFilePath.EndsWith(".csv"))
                        {
                            DataExportService.ExportToCsv(products, selectedFilePath);
                        }
                        else if (selectedFilePath.EndsWith(".json"))
                        {
                            DataExportService.ExportToJson(products, selectedFilePath);
                        }
                        else if (selectedFilePath.EndsWith(".xml"))
                        {
                            DataExportService.ExportToXml(products, selectedFilePath);
                        }

                        MessageBox.Show("Products data has been successfully exported.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error exporting data to file: {FilePath}", selectedFilePath);
                        MessageBox.Show($"Error exporting data: {ex.Message}");
                    }
                }
            }
        }
    }
}

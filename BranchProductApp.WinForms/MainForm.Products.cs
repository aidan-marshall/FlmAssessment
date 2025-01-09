using BranchProductApp.Core.Parsers;
using BranchProductApp.Core.Products;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async Task LoadProducts()
        {
            try
            {
                var products = await productService.GetProducts();
                ProductDataGridView.DataSource = products.ToList();
                ProductDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error loading products.");
            }
        }

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
                    ".csv" => CsvImporter.ParseCsv(filePath, new ProductMap()),
                    ".json" => JsonImporter.ParseProductsJson(filePath),
                    ".xml" => XmlImporter.DeserializeProductXml(filePath),
                    _ => throw new NotSupportedException("File format not supported")
                };

                await productService.AddProducts(products);
                await LoadProducts();
                MessageBox.Show("Data imported successfully!");
            }
            catch (NotSupportedException ex)
            {
                logger.LogWarning(ex, "Unsupported file format: {FilePath}", filePath);
                MessageBox.Show($"Error importing data: Unsupported file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error importing data from file: {FilePath}", filePath);
                MessageBox.Show($"Error importing data: Something went wrong");
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
                        MessageBox.Show($"Error exporting data: Something went wrong.");
                    }
                }
            }
        }

        private async void ProductDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == ProductDataGridView.Columns["ProductsColumnDeleteButton"]!.Index)
            {
                var confirmResult = Helpers.Helpers.Confirm("delete", "product");

                if (confirmResult == DialogResult.Yes)
                {
                    var selectedProduct = ProductDataGridView.Rows[e.RowIndex].DataBoundItem as Product;
                    if (selectedProduct != null)
                    {
                        try
                        {
                            await productService.DeleteProduct(selectedProduct.Id);

                            await LoadProducts();

                            var selectedBranchId = GetSelectedBranchId();
                            if (selectedBranchId == -1)
                            {
                                return;
                            }
                            await LoadBranchProducts(selectedBranchId);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Error deleting product: {ProductId}", selectedProduct.Id);
                            MessageBox.Show($"Error deleting product: Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == ProductDataGridView.Columns["ProductsColumnUpdateButton"]!.Index)
            {
                var selectedProduct = ProductDataGridView.Rows[e.RowIndex].DataBoundItem as Product;
                if (selectedProduct != null)
                {
                    var confirmResult = Helpers.Helpers.Confirm("update", "product");


                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(ProductNameTextBox.Text))
                                selectedProduct.Name = ProductNameTextBox.Text;

                            if (WeightedItemCheckBox.Checked != selectedProduct.WeightedItem)
                                selectedProduct.WeightedItem = WeightedItemCheckBox.Checked;

                            if (decimal.TryParse(ProductPriceTextBox.Text, CultureInfo.InvariantCulture, out var price) && price != selectedProduct.SuggestedSellingPrice)
                                selectedProduct.SuggestedSellingPrice = price;

                            await productService.UpdateProduct(selectedProduct);
                            await LoadProducts();
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Error updating product: {ProductId}", selectedProduct.Id);
                            MessageBox.Show($"Error updating product: Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void AddProductButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text))
            {
                MessageBox.Show("Please enter a product name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(ProductPriceTextBox.Text,
                          NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                          CultureInfo.InvariantCulture,
                          out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newProduct = new Product
            {
                Name = ProductNameTextBox.Text,
                WeightedItem = WeightedItemCheckBox.Checked,
                SuggestedSellingPrice = price
            };

            try
            {
                await productService.CreateProduct(newProduct);
                await LoadProducts();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating product: {ProductName}", newProduct.Name);
                MessageBox.Show($"Error creating product: Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

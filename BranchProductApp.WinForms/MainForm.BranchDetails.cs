using BranchProductApp.Core.Parsers;
using Microsoft.Extensions.Logging;
using BranchProductApp.Core.ProductBranchMappings;
using BranchProductApp.Core.Products;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async void BranchDetailsImportButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var filePath = openFileDialog.FileName;
            var fileExtension = Path.GetExtension(filePath).ToLower();

            try
            {
                var branchDetails = fileExtension switch
                {
                    ".csv" => CsvImporter.ParseCsvMappings(filePath),
                    ".json" => throw new NotImplementedException(),
                    ".xml" => throw new NotImplementedException(),
                    _ => throw new NotSupportedException("File format not supported")
                };

                var validMappings = await ValidateMappings(branchDetails);

                if (validMappings.Any())
                {

                    await productBranchMappingService.AddMappings(validMappings);
                    await LoadBranches();
                    logger.LogInformation("Branch details imported successfully");
                    MessageBox.Show("Branch details imported successfully!");
                }
                else
                {
                    logger.LogWarning("No valid branch details found in the file");
                    MessageBox.Show("No valid branch details found in the file");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error importing branch details");
                MessageBox.Show($"Error importing branch details: {ex.Message}");
            }
        }

        private async Task<List<ProductBranchMapping>> ValidateMappings(List<ProductBranchMapping> mappings)
        {
            var existingBranches = await branchService.GetBranches();
            var existingProducts = await productService.GetProducts();

            var validMappings = mappings.Where(m =>
                existingBranches.Any(b => b.Id == m.BranchId) &&
                existingProducts.Any(p => p.Id == m.ProductId)
            ).ToList();

            var invalidMappings = mappings.Except(validMappings).ToList();

            foreach (var mapping in invalidMappings)
            {
                logger.LogWarning("Invalid mapping found: {BranchId}, {ProductId}", mapping.BranchId, mapping.ProductId);
                logger.LogInformation("Skipping...");
            }

            return validMappings;
        }

        private async void BranchDetailsExportButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save Branch Details Export";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = saveFileDialog.FileName;
                    var branchDetails = await productBranchMappingService.GetAllMappings();

                    if (selectedFilePath.EndsWith(".csv"))
                    {
                        DataExportService.ExportToCsv(branchDetails, selectedFilePath);
                    }
                    else if (selectedFilePath.EndsWith(".json"))
                    {
                        DataExportService.ExportToJson(branchDetails, selectedFilePath);
                    }
                    else if (selectedFilePath.EndsWith(".xml"))
                    {
                        DataExportService.ExportToXml(branchDetails, selectedFilePath);
                    }

                    MessageBox.Show("Branch details have been successfully exported.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int GetSelectedBranchId()
        {
            if (BranchComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a branch.", "No Branch Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            if (BranchComboBox.SelectedValue is int selectedBranchId)
            {
                return selectedBranchId;
            }

            return -1;
        }

        private async void BranchDetailsAddProductButton_Click(object sender, EventArgs e)
        {
            if (BranchComboBox.SelectedValue is int selectedBranchId && ProductToAddComboBox.SelectedValue is int selectedProductId)
            {
                try
                {
                    await productBranchMappingService.AssignProductToBranch(selectedBranchId, selectedProductId);
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadBranchProducts(selectedBranchId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a branch and a product.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BranchDetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedBranchId = GetSelectedBranchId();

                if (selectedBranchId == -1)
                {
                    return;
                }

                var selectedProduct = BranchDetailsDataGridView.Rows[e.RowIndex].DataBoundItem as Product;

                if (selectedProduct == null)
                {
                    MessageBox.Show("Please select a product.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logger.LogWarning("No product selected");
                    return;
                }

                await productBranchMappingService.UnassignProductFromBranch(selectedBranchId, selectedProduct.Id);
                await LoadBranchProducts(selectedBranchId);
                MessageBox.Show("Product removed from branch.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while handling cell content click");
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BranchComboBox.SelectedValue != null)
            {
                if (BranchComboBox.SelectedValue is int selectedBranchId)
                {
                    await LoadBranchProducts(selectedBranchId);
                }
            }
        }

        private async Task LoadBranchProducts(int selectedBranchId)
        {
            var branchProducts = await productBranchMappingService.GetProductsForBranch(selectedBranchId);
            var allProducts = await productService.GetProducts();
            var availableProducts = allProducts.Where(p => !branchProducts.Any(bp => bp.Id == p.Id)).ToList();

            BranchDetailsDataGridView.DataSource = branchProducts.ToList();
            BranchDetailsDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
            ProductToAddComboBox.DataSource = availableProducts;
            ProductToAddComboBox.DisplayMember = "Name";
            ProductToAddComboBox.ValueMember = "Id";
        }

        private async Task InitializeBranchDetails()
        {
            try
            {
                var branches = await branchService.GetBranches();

                if (branches.Any())
                {
                    var firstBranch = branches.First();
                    BranchComboBox.SelectedValue = firstBranch.Id;
                    await LoadBranchProducts(firstBranch.Id);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error initializing branch details");
                MessageBox.Show("Error initializing branch details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

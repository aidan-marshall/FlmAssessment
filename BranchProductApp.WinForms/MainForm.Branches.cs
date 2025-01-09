using BranchProductApp.Core.Parsers;
using BranchProductApp.Core.Branches;
using Microsoft.Extensions.Logging;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async Task LoadBranches()
        {
            try
            {
                var branches = await branchService.GetBranches();

                if (!branches.Any())
                {
                    BranchComboBox.Text = "No branches available...";
                    ProductToAddComboBox.DataSource = null;
                }

                BranchDataGridView.DataSource = branches.ToList();
                BranchDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
                BranchComboBox.DataSource = branches.ToList();
                BranchComboBox.DisplayMember = "Name";
                BranchComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error loading branches");
                MessageBox.Show("Error loading branches: Something went wrong");
            }
        }

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
                    ".csv" => CsvImporter.ParseCsv(filePath, new BranchMap()),
                    ".json" => JsonImporter.ParseBranchesJson(filePath),
                    ".xml" => XmlImporter.DeserializeBranchXml(filePath),
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

                    try
                    {
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
                            var branchDtos = DataExportService.MapBranchesToDtos(branches);
                            DataExportService.ExportToXml(branchDtos, selectedFilePath);
                        }

                        MessageBox.Show("Branches data has been successfully exported.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error exporting data to file: {FilePath}", selectedFilePath);
                        MessageBox.Show($"Error exporting data: {ex.Message}");
                    }
                }
            }
        }

        private async void AddBranchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(BranchNameTextBox.Text))
                {
                    MessageBox.Show("Please enter a branch name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(BranchTelephoneTextBox.Text))
                {
                    MessageBox.Show("Please enter a telephone number for the branch.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (BranchOpenDatePicker.Value == DateTime.Now)
                {
                    MessageBox.Show("Please select a valid open date for the branch.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Helpers.Helpers.IsValidPhoneNumber(BranchTelephoneTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid telephone number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newBranch = new Branch
                {
                    Name = BranchNameTextBox.Text,
                    TelephoneNumber = BranchTelephoneTextBox.Text,
                    OpenDate = BranchOpenDatePicker.Value
                };

                await branchService.CreateBranch(newBranch);
                await LoadBranches();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding branch: {BranchName}", BranchNameTextBox.Text);
                MessageBox.Show("Error adding branch: Something went wrong.");
            }
        }

        private async void BranchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == BranchDataGridView.Columns["BranchColumnDeleteButton"]!.Index)
                {
                    await HandleBranchDelete(e.RowIndex);
                }
                else if (e.ColumnIndex == BranchDataGridView.Columns["BranchColumnUpdateButton"]!.Index)
                {
                    await HandleBranchUpdate(e.RowIndex);
                }
            }
        }

        private async Task HandleBranchDelete(int rowIndex)
        {
            try
            {
                var selectedBranch = BranchDataGridView.Rows[rowIndex].DataBoundItem as Branch;
                if (selectedBranch != null)
                {
                    var confirmResult = Confirm("delete", "branch");
                    if (confirmResult == DialogResult.Yes)
                    {
                        await branchService.DeleteBranch(selectedBranch.Id);
                        await LoadBranches();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting branch");
                MessageBox.Show("Error deleting branch: Something went wrong.");
            }
        }

        private async Task HandleBranchUpdate(int rowIndex)
        {
            try
            {
                var selectedBranch = BranchDataGridView.Rows[rowIndex].DataBoundItem as Branch;
                if (selectedBranch != null)
                {
                    var confirmResult = Confirm("update", "branch");
                    if (confirmResult == DialogResult.Yes)
                    {
                        selectedBranch.Name = BranchNameTextBox.Text;
                        selectedBranch.TelephoneNumber = BranchTelephoneTextBox.Text;
                        selectedBranch.OpenDate = BranchOpenDatePicker.Value;

                        await branchService.UpdateBranch(selectedBranch);
                        await LoadBranches();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating branch");
                MessageBox.Show("Error updating branch: Something went wrong.");
            }
        }
    }
}

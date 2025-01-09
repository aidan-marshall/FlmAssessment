using BranchProductApp.Core.Parsers;
using BranchProductApp.Core.Branches;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async Task LoadBranches()
        {
            var branches = await branchService.GetBranches();
            BranchDataGridView.DataSource = branches.ToList();
            BranchDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
            BranchComboBox.DataSource = branches.ToList();
            BranchComboBox.DisplayMember = "Name";
            BranchComboBox.ValueMember = "Id";
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
                    ".csv" => CsvImporter.ParseCsvForBranches(filePath) ,
                    ".json" => JsonParser.ParseBranchesJson(filePath),
                    ".xml" => XmlParser.DeserializeBranchXml(filePath),
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

        private async void AddBranchButton_Click(object sender, EventArgs e)
        {
            var newBranch = new Branch
            {
                Name = BranchNameTextBox.Text,
                TelephoneNumber = BranchTelephoneTextBox.Text,
                OpenDate = BranchOpenDatePicker.Value
            };

            await branchService.CreateBranch(newBranch);
            await LoadBranches();
        }

        private async void BranchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == BranchDataGridView.Columns["BranchColumnDeleteButton"].Index)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this branch?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    var selectedBranch = BranchDataGridView.Rows[e.RowIndex].DataBoundItem as Branch;
                    if (selectedBranch != null)
                    {
                        await branchService.DeleteBranch(selectedBranch.Id);

                        await LoadBranches();
                    }
                }
            }
            else if (e.RowIndex >= 0)
            {
                var selectedBranch = BranchDataGridView.Rows[e.RowIndex].DataBoundItem as Branch;
                if (selectedBranch != null)
                {
                    BranchNameTextBox.Text = selectedBranch.Name;
                    BranchTelephoneTextBox.Text = selectedBranch.TelephoneNumber;
                    BranchOpenDatePicker.Value = selectedBranch.OpenDate ?? DateTime.Now;
                }
            }
        }

        private async void EditBranchButton_Click(object sender, EventArgs e)
        {
            var selectedBranch = BranchDataGridView.CurrentRow?.DataBoundItem as Branch;
            if (selectedBranch != null)
            {
                selectedBranch.Name = BranchNameTextBox.Text;
                selectedBranch.TelephoneNumber = BranchTelephoneTextBox.Text;
                selectedBranch.OpenDate = BranchOpenDatePicker.Value;
                await branchService.UpdateBranch(selectedBranch);
                await LoadBranches();
            }
        }

        private void BranchesTab_Click(object sender, EventArgs e)
        {

        }

        private void BranchNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BranchTelephoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

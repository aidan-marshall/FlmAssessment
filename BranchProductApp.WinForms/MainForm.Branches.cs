﻿using BranchProductApp.Core.Parsers;
using BranchProductApp.Core.Branches;
using System.Text.RegularExpressions;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private async Task LoadBranches()
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
            }
        }

        private async void AddBranchButton_Click(object sender, EventArgs e)
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

            // Regex to ensure the telephone number contains only digits (allowing spaces, dashes, or parentheses for formatting)
            var phoneRegex = new Regex(@"^\+?(\d[\d\- ]{7,}\d$)");
            if (!phoneRegex.IsMatch(BranchTelephoneTextBox.Text))
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

        private async void BranchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == BranchDataGridView.Columns["BranchColumnDeleteButton"]!.Index)
            {
                var confirmResult = ConfirmDelete();

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
            else if (e.RowIndex >= 0 && e.ColumnIndex == BranchDataGridView.Columns["BranchColumnUpdateButton"]!.Index)
            {
                var selectedBranch = BranchDataGridView.Rows[e.RowIndex].DataBoundItem as Branch;
                if (selectedBranch != null)
                {
                    var confirmResult = ConfirmUpdate();


                    if (confirmResult == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(BranchNameTextBox.Text))
                            selectedBranch.Name = BranchNameTextBox.Text;

                        if (!string.IsNullOrEmpty(BranchTelephoneTextBox.Text))
                            selectedBranch.TelephoneNumber = BranchTelephoneTextBox.Text;

                        if (BranchOpenDatePicker.Value != DateTime.Now)
                            selectedBranch.OpenDate = BranchOpenDatePicker.Value;

                        await branchService.UpdateBranch(selectedBranch);
                        await LoadBranches();
                    }
                }
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

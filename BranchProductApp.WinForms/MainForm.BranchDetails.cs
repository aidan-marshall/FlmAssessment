﻿using BranchProductApp.Core.Parsers;

namespace BranchProductApp.WinForms
{
    public partial class MainForm
    {
        private void BranchDetailsImportButton_Click(object sender, EventArgs e)
        {

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
    }
}

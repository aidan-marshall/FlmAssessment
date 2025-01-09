namespace BranchProductApp.WinForms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        BranchesTab = new TabPage();
        BranchesExportButton = new Button();
        BranchesImportButton = new Button();
        AddBranchButton = new Button();
        BranchDataGridView = new DataGridView();
        BranchColumnDeleteButton = new DataGridViewButtonColumn();
        BranchColumnUpdateButton = new DataGridViewButtonColumn();
        BranchOpenDatePicker = new DateTimePicker();
        BranchTelephoneTextBox = new TextBox();
        BranchNameTextBox = new TextBox();
        ProductsTab = new TabPage();
        ProductExportButton = new Button();
        ProductsImportButton = new Button();
        AddProductButton = new Button();
        ProductDataGridView = new DataGridView();
        ProductsColumnDeleteButton = new DataGridViewButtonColumn();
        ProductsColumnUpdateButton = new DataGridViewButtonColumn();
        WeightedItemCheckBox = new CheckBox();
        ProductPriceTextBox = new TextBox();
        ProductNameTextBox = new TextBox();
        BranchDetailsTab = new TabPage();
        BranchDetailsExportButton = new Button();
        BranchDetailsImportButton = new Button();
        ProductToAddComboBox = new ComboBox();
        BranchDetailsAddProductButton = new Button();
        BranchDetailsDataGridView = new DataGridView();
        BranchDetailsRemoveButton = new DataGridViewButtonColumn();
        BranchComboBox = new ComboBox();
        sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
        tabControl1.SuspendLayout();
        BranchesTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)BranchDataGridView).BeginInit();
        ProductsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ProductDataGridView).BeginInit();
        BranchDetailsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)BranchDetailsDataGridView).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(BranchesTab);
        tabControl1.Controls.Add(ProductsTab);
        tabControl1.Controls.Add(BranchDetailsTab);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(793, 445);
        tabControl1.TabIndex = 0;
        // 
        // BranchesTab
        // 
        BranchesTab.Controls.Add(BranchesExportButton);
        BranchesTab.Controls.Add(BranchesImportButton);
        BranchesTab.Controls.Add(AddBranchButton);
        BranchesTab.Controls.Add(BranchDataGridView);
        BranchesTab.Controls.Add(BranchOpenDatePicker);
        BranchesTab.Controls.Add(BranchTelephoneTextBox);
        BranchesTab.Controls.Add(BranchNameTextBox);
        BranchesTab.Location = new Point(4, 24);
        BranchesTab.Name = "BranchesTab";
        BranchesTab.Padding = new Padding(3);
        BranchesTab.Size = new Size(785, 417);
        BranchesTab.TabIndex = 0;
        BranchesTab.Text = "Branches";
        BranchesTab.UseVisualStyleBackColor = true;
        // 
        // BranchesExportButton
        // 
        BranchesExportButton.Location = new Point(702, 7);
        BranchesExportButton.Name = "BranchesExportButton";
        BranchesExportButton.Size = new Size(75, 23);
        BranchesExportButton.TabIndex = 8;
        BranchesExportButton.Text = "Export";
        BranchesExportButton.UseVisualStyleBackColor = true;
        BranchesExportButton.Click += BranchesExportButton_Click;
        // 
        // BranchesImportButton
        // 
        BranchesImportButton.Location = new Point(640, 7);
        BranchesImportButton.Name = "BranchesImportButton";
        BranchesImportButton.Size = new Size(56, 23);
        BranchesImportButton.TabIndex = 7;
        BranchesImportButton.Text = "Import";
        BranchesImportButton.UseVisualStyleBackColor = true;
        BranchesImportButton.Click += BranchesImportButton_Click;
        // 
        // AddBranchButton
        // 
        AddBranchButton.Location = new Point(298, 7);
        AddBranchButton.Name = "AddBranchButton";
        AddBranchButton.Size = new Size(75, 23);
        AddBranchButton.TabIndex = 4;
        AddBranchButton.Text = "Create";
        AddBranchButton.UseVisualStyleBackColor = true;
        AddBranchButton.Click += AddBranchButton_Click;
        // 
        // BranchDataGridView
        // 
        BranchDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        BranchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BranchDataGridView.Columns.AddRange(new DataGridViewColumn[] { BranchColumnDeleteButton, BranchColumnUpdateButton });
        BranchDataGridView.Location = new Point(8, 36);
        BranchDataGridView.Name = "BranchDataGridView";
        BranchDataGridView.ReadOnly = true;
        BranchDataGridView.Size = new Size(785, 385);
        BranchDataGridView.TabIndex = 3;
        BranchDataGridView.CellContentClick += BranchDataGridView_CellContentClick;
        // 
        // BranchColumnDeleteButton
        // 
        BranchColumnDeleteButton.HeaderText = "Delete Branch";
        BranchColumnDeleteButton.Name = "BranchColumnDeleteButton";
        BranchColumnDeleteButton.ReadOnly = true;
        BranchColumnDeleteButton.Text = "Delete";
        BranchColumnDeleteButton.UseColumnTextForButtonValue = true;
        // 
        // BranchColumnUpdateButton
        // 
        BranchColumnUpdateButton.HeaderText = "Update Branch";
        BranchColumnUpdateButton.Name = "BranchColumnUpdateButton";
        BranchColumnUpdateButton.ReadOnly = true;
        BranchColumnUpdateButton.Text = "Update";
        BranchColumnUpdateButton.UseColumnTextForButtonValue = true;
        // 
        // BranchOpenDatePicker
        // 
        BranchOpenDatePicker.Location = new Point(274, 6);
        BranchOpenDatePicker.Name = "BranchOpenDatePicker";
        BranchOpenDatePicker.Size = new Size(18, 23);
        BranchOpenDatePicker.TabIndex = 2;
        // 
        // BranchTelephoneTextBox
        // 
        BranchTelephoneTextBox.Location = new Point(141, 7);
        BranchTelephoneTextBox.Name = "BranchTelephoneTextBox";
        BranchTelephoneTextBox.Size = new Size(127, 23);
        BranchTelephoneTextBox.TabIndex = 1;
        BranchTelephoneTextBox.Text = "Enter contact number...";
        // 
        // BranchNameTextBox
        // 
        BranchNameTextBox.Location = new Point(8, 7);
        BranchNameTextBox.Name = "BranchNameTextBox";
        BranchNameTextBox.Size = new Size(129, 23);
        BranchNameTextBox.TabIndex = 0;
        BranchNameTextBox.Text = "Enter branch name...";
        // 
        // ProductsTab
        // 
        ProductsTab.Controls.Add(ProductExportButton);
        ProductsTab.Controls.Add(ProductsImportButton);
        ProductsTab.Controls.Add(AddProductButton);
        ProductsTab.Controls.Add(ProductDataGridView);
        ProductsTab.Controls.Add(WeightedItemCheckBox);
        ProductsTab.Controls.Add(ProductPriceTextBox);
        ProductsTab.Controls.Add(ProductNameTextBox);
        ProductsTab.Location = new Point(4, 24);
        ProductsTab.Name = "ProductsTab";
        ProductsTab.Padding = new Padding(3);
        ProductsTab.Size = new Size(785, 417);
        ProductsTab.TabIndex = 1;
        ProductsTab.Text = "Products";
        ProductsTab.UseVisualStyleBackColor = true;
        // 
        // ProductExportButton
        // 
        ProductExportButton.Location = new Point(702, 4);
        ProductExportButton.Name = "ProductExportButton";
        ProductExportButton.Size = new Size(75, 23);
        ProductExportButton.TabIndex = 8;
        ProductExportButton.Text = "Export";
        ProductExportButton.UseVisualStyleBackColor = true;
        ProductExportButton.Click += ProductExportButton_Click;
        // 
        // ProductsImportButton
        // 
        ProductsImportButton.Location = new Point(638, 4);
        ProductsImportButton.Name = "ProductsImportButton";
        ProductsImportButton.Size = new Size(58, 23);
        ProductsImportButton.TabIndex = 7;
        ProductsImportButton.Text = "Import";
        ProductsImportButton.UseVisualStyleBackColor = true;
        ProductsImportButton.Click += ProductsImportButton_Click;
        // 
        // AddProductButton
        // 
        AddProductButton.Location = new Point(327, 6);
        AddProductButton.Name = "AddProductButton";
        AddProductButton.Size = new Size(75, 23);
        AddProductButton.TabIndex = 4;
        AddProductButton.Text = "Create";
        AddProductButton.UseVisualStyleBackColor = true;
        AddProductButton.Click += AddProductButton_Click;
        // 
        // ProductDataGridView
        // 
        ProductDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        ProductDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ProductDataGridView.Columns.AddRange(new DataGridViewColumn[] { ProductsColumnDeleteButton, ProductsColumnUpdateButton });
        ProductDataGridView.Location = new Point(0, 33);
        ProductDataGridView.Name = "ProductDataGridView";
        ProductDataGridView.Size = new Size(785, 384);
        ProductDataGridView.TabIndex = 3;
        ProductDataGridView.CellContentClick += ProductDataGridView_CellContentClick;
        // 
        // ProductsColumnDeleteButton
        // 
        ProductsColumnDeleteButton.HeaderText = "Delete Product";
        ProductsColumnDeleteButton.Name = "ProductsColumnDeleteButton";
        ProductsColumnDeleteButton.Text = "Delete";
        ProductsColumnDeleteButton.UseColumnTextForButtonValue = true;
        // 
        // ProductsColumnUpdateButton
        // 
        ProductsColumnUpdateButton.HeaderText = "Update Product";
        ProductsColumnUpdateButton.Name = "ProductsColumnUpdateButton";
        ProductsColumnUpdateButton.Text = "Update";
        ProductsColumnUpdateButton.UseColumnTextForButtonValue = true;
        // 
        // WeightedItemCheckBox
        // 
        WeightedItemCheckBox.AutoSize = true;
        WeightedItemCheckBox.Location = new Point(114, 8);
        WeightedItemCheckBox.Name = "WeightedItemCheckBox";
        WeightedItemCheckBox.Size = new Size(101, 19);
        WeightedItemCheckBox.TabIndex = 2;
        WeightedItemCheckBox.Text = "WeightedItem";
        WeightedItemCheckBox.UseVisualStyleBackColor = true;
        // 
        // ProductPriceTextBox
        // 
        ProductPriceTextBox.Location = new Point(221, 6);
        ProductPriceTextBox.Name = "ProductPriceTextBox";
        ProductPriceTextBox.Size = new Size(100, 23);
        ProductPriceTextBox.TabIndex = 1;
        ProductPriceTextBox.Text = "Product price...";
        // 
        // ProductNameTextBox
        // 
        ProductNameTextBox.Location = new Point(8, 6);
        ProductNameTextBox.Name = "ProductNameTextBox";
        ProductNameTextBox.Size = new Size(100, 23);
        ProductNameTextBox.TabIndex = 0;
        ProductNameTextBox.Text = "Product name...";
        ProductNameTextBox.TextChanged += ProductNameTextBox_TextChanged;
        // 
        // BranchDetailsTab
        // 
        BranchDetailsTab.Controls.Add(BranchDetailsExportButton);
        BranchDetailsTab.Controls.Add(BranchDetailsImportButton);
        BranchDetailsTab.Controls.Add(ProductToAddComboBox);
        BranchDetailsTab.Controls.Add(BranchDetailsAddProductButton);
        BranchDetailsTab.Controls.Add(BranchDetailsDataGridView);
        BranchDetailsTab.Controls.Add(BranchComboBox);
        BranchDetailsTab.Location = new Point(4, 24);
        BranchDetailsTab.Name = "BranchDetailsTab";
        BranchDetailsTab.Padding = new Padding(3);
        BranchDetailsTab.Size = new Size(785, 417);
        BranchDetailsTab.TabIndex = 2;
        BranchDetailsTab.Text = "Branch Details";
        BranchDetailsTab.UseVisualStyleBackColor = true;
        // 
        // BranchDetailsExportButton
        // 
        BranchDetailsExportButton.Location = new Point(702, 6);
        BranchDetailsExportButton.Name = "BranchDetailsExportButton";
        BranchDetailsExportButton.Size = new Size(75, 23);
        BranchDetailsExportButton.TabIndex = 6;
        BranchDetailsExportButton.Text = "Export";
        BranchDetailsExportButton.UseVisualStyleBackColor = true;
        BranchDetailsExportButton.Click += BranchDetailsExportButton_Click;
        // 
        // BranchDetailsImportButton
        // 
        BranchDetailsImportButton.Location = new Point(621, 5);
        BranchDetailsImportButton.Name = "BranchDetailsImportButton";
        BranchDetailsImportButton.Size = new Size(75, 23);
        BranchDetailsImportButton.TabIndex = 5;
        BranchDetailsImportButton.Text = "Import";
        BranchDetailsImportButton.UseVisualStyleBackColor = true;
        BranchDetailsImportButton.Click += BranchDetailsImportButton_Click;
        // 
        // ProductToAddComboBox
        // 
        ProductToAddComboBox.FormattingEnabled = true;
        ProductToAddComboBox.Location = new Point(154, 6);
        ProductToAddComboBox.Name = "ProductToAddComboBox";
        ProductToAddComboBox.Size = new Size(143, 23);
        ProductToAddComboBox.TabIndex = 4;
        ProductToAddComboBox.Text = "Select a new product...";
        // 
        // BranchDetailsAddProductButton
        // 
        BranchDetailsAddProductButton.Location = new Point(303, 6);
        BranchDetailsAddProductButton.Name = "BranchDetailsAddProductButton";
        BranchDetailsAddProductButton.Size = new Size(86, 23);
        BranchDetailsAddProductButton.TabIndex = 3;
        BranchDetailsAddProductButton.Text = "Add Product";
        BranchDetailsAddProductButton.UseVisualStyleBackColor = true;
        BranchDetailsAddProductButton.Click += BranchDetailsAddProductButton_Click;
        // 
        // BranchDetailsDataGridView
        // 
        BranchDetailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        BranchDetailsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BranchDetailsDataGridView.Columns.AddRange(new DataGridViewColumn[] { BranchDetailsRemoveButton });
        BranchDetailsDataGridView.Location = new Point(0, 34);
        BranchDetailsDataGridView.Name = "BranchDetailsDataGridView";
        BranchDetailsDataGridView.Size = new Size(785, 383);
        BranchDetailsDataGridView.TabIndex = 1;
        BranchDetailsDataGridView.CellContentClick += BranchDetailsDeleteColumnButton_CellContentClick;
        // 
        // BranchDetailsRemoveButton
        // 
        BranchDetailsRemoveButton.HeaderText = "Delete";
        BranchDetailsRemoveButton.Name = "BranchDetailsRemoveButton";
        BranchDetailsRemoveButton.Text = "Remove Product";
        BranchDetailsRemoveButton.UseColumnTextForButtonValue = true;
        // 
        // BranchComboBox
        // 
        BranchComboBox.FormattingEnabled = true;
        BranchComboBox.Location = new Point(3, 6);
        BranchComboBox.Name = "BranchComboBox";
        BranchComboBox.Size = new Size(121, 23);
        BranchComboBox.TabIndex = 0;
        BranchComboBox.Text = "Select a Branch...";
        BranchComboBox.SelectedIndexChanged += BranchComboBox_SelectedIndexChanged;
        // 
        // sqlCommand1
        // 
        sqlCommand1.CommandTimeout = 30;
        sqlCommand1.EnableOptimizedParameterBinding = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(793, 445);
        Controls.Add(tabControl1);
        Name = "MainForm";
        Text = "Form1";
        tabControl1.ResumeLayout(false);
        BranchesTab.ResumeLayout(false);
        BranchesTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)BranchDataGridView).EndInit();
        ProductsTab.ResumeLayout(false);
        ProductsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)ProductDataGridView).EndInit();
        BranchDetailsTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)BranchDetailsDataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage BranchesTab;
    private TabPage ProductsTab;
    private TextBox BranchTelephoneTextBox;
    private TextBox BranchNameTextBox;
    private Button DeleteBranchButton;
    private Button AddBranchButton;
    private DataGridView BranchDataGridView;
    private DateTimePicker BranchOpenDatePicker;
    private TextBox ProductPriceTextBox;
    private TextBox ProductNameTextBox;
    private Button AddProductButton;
    private DataGridView ProductDataGridView;
    private CheckBox WeightedItemCheckBox;
    private TabPage BranchDetailsTab;
    private DataGridView BranchDetailsDataGridView;
    private ComboBox BranchComboBox;
    private Button BranchDetailsAddProductButton;
    private ComboBox ProductToAddComboBox;
    private Button BranchesExportButton;
    private Button BranchesImportButton;
    private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    private Button ProductExportButton;
    private Button ProductsImportButton;
    private Button BranchDetailsExportButton;
    private Button BranchDetailsImportButton;
    private DataGridViewButtonColumn BranchDetailsRemoveButton;
    private DataGridViewButtonColumn BranchColumnDeleteButton;
    private DataGridViewButtonColumn BranchColumnUpdateButton;
    private DataGridViewButtonColumn ProductsColumnDeleteButton;
    private DataGridViewButtonColumn ProductsColumnUpdateButton;
}
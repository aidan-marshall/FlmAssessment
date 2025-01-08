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
        DeleteBranchButton = new Button();
        EditBranchButton = new Button();
        AddBranchButton = new Button();
        BranchDataGridView = new DataGridView();
        BranchOpenDatePicker = new DateTimePicker();
        BranchTelephoneTextBox = new TextBox();
        BranchNameTextBox = new TextBox();
        ProductsTab = new TabPage();
        DeleteProductButton = new Button();
        EditProductButton = new Button();
        AddProductButton = new Button();
        ProductDataGridView = new DataGridView();
        WeightedItemCheckBox = new CheckBox();
        ProductPriceTextBox = new TextBox();
        ProductNameTextBox = new TextBox();
        BranchDetailsTab = new TabPage();
        ProductToAddComboBox = new ComboBox();
        BranchDetailsAddProductButton = new Button();
        BranchDetailsDeleteButton = new Button();
        BranchDetailsDataGridView = new DataGridView();
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
        BranchesTab.Controls.Add(DeleteBranchButton);
        BranchesTab.Controls.Add(EditBranchButton);
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
        BranchesTab.Click += BranchesTab_Click;
        // 
        // DeleteBranchButton
        // 
        DeleteBranchButton.Location = new Point(170, 35);
        DeleteBranchButton.Name = "DeleteBranchButton";
        DeleteBranchButton.Size = new Size(75, 23);
        DeleteBranchButton.TabIndex = 6;
        DeleteBranchButton.Text = "Delete";
        DeleteBranchButton.UseVisualStyleBackColor = true;
        DeleteBranchButton.Click += DeleteBranchButton_Click;
        // 
        // EditBranchButton
        // 
        EditBranchButton.Location = new Point(89, 35);
        EditBranchButton.Name = "EditBranchButton";
        EditBranchButton.Size = new Size(75, 23);
        EditBranchButton.TabIndex = 5;
        EditBranchButton.Text = "Edit";
        EditBranchButton.UseVisualStyleBackColor = true;
        EditBranchButton.Click += EditBranchButton_Click;
        // 
        // AddBranchButton
        // 
        AddBranchButton.Location = new Point(8, 35);
        AddBranchButton.Name = "AddBranchButton";
        AddBranchButton.Size = new Size(75, 23);
        AddBranchButton.TabIndex = 4;
        AddBranchButton.Text = "Create";
        AddBranchButton.UseVisualStyleBackColor = true;
        AddBranchButton.Click += AddBranchButton_Click;
        // 
        // BranchDataGridView
        // 
        BranchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BranchDataGridView.Location = new Point(0, 64);
        BranchDataGridView.Name = "BranchDataGridView";
        BranchDataGridView.Size = new Size(785, 353);
        BranchDataGridView.TabIndex = 3;
        BranchDataGridView.CellContentClick += BranchDataGridView_CellContentClick;
        // 
        // BranchOpenDatePicker
        // 
        BranchOpenDatePicker.Location = new Point(218, 6);
        BranchOpenDatePicker.Name = "BranchOpenDatePicker";
        BranchOpenDatePicker.Size = new Size(200, 23);
        BranchOpenDatePicker.TabIndex = 2;
        // 
        // BranchTelephoneTextBox
        // 
        BranchTelephoneTextBox.Location = new Point(112, 6);
        BranchTelephoneTextBox.Name = "BranchTelephoneTextBox";
        BranchTelephoneTextBox.Size = new Size(100, 23);
        BranchTelephoneTextBox.TabIndex = 1;
        BranchTelephoneTextBox.TextChanged += BranchTelephoneTextBox_TextChanged;
        // 
        // BranchNameTextBox
        // 
        BranchNameTextBox.Location = new Point(6, 6);
        BranchNameTextBox.Name = "BranchNameTextBox";
        BranchNameTextBox.Size = new Size(100, 23);
        BranchNameTextBox.TabIndex = 0;
        BranchNameTextBox.TextChanged += BranchNameTextBox_TextChanged;
        // 
        // ProductsTab
        // 
        ProductsTab.Controls.Add(DeleteProductButton);
        ProductsTab.Controls.Add(EditProductButton);
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
        // DeleteProductButton
        // 
        DeleteProductButton.Location = new Point(170, 35);
        DeleteProductButton.Name = "DeleteProductButton";
        DeleteProductButton.Size = new Size(75, 23);
        DeleteProductButton.TabIndex = 6;
        DeleteProductButton.Text = "Delete";
        DeleteProductButton.UseVisualStyleBackColor = true;
        DeleteProductButton.Click += DeleteProductButton_Click;
        // 
        // EditProductButton
        // 
        EditProductButton.Location = new Point(89, 35);
        EditProductButton.Name = "EditProductButton";
        EditProductButton.Size = new Size(75, 23);
        EditProductButton.TabIndex = 5;
        EditProductButton.Text = "Edit";
        EditProductButton.UseVisualStyleBackColor = true;
        EditProductButton.Click += EditProductButton_Click;
        // 
        // AddProductButton
        // 
        AddProductButton.Location = new Point(8, 35);
        AddProductButton.Name = "AddProductButton";
        AddProductButton.Size = new Size(75, 23);
        AddProductButton.TabIndex = 4;
        AddProductButton.Text = "Create";
        AddProductButton.UseVisualStyleBackColor = true;
        AddProductButton.Click += AddProductButton_Click;
        // 
        // ProductDataGridView
        // 
        ProductDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        ProductDataGridView.Location = new Point(8, 64);
        ProductDataGridView.Name = "ProductDataGridView";
        ProductDataGridView.Size = new Size(769, 345);
        ProductDataGridView.TabIndex = 3;
        ProductDataGridView.CellContentClick += ProductDataGridView_CellContentClick;
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
        WeightedItemCheckBox.CheckedChanged += WeightedItemCheckBox_CheckedChanged;
        // 
        // ProductPriceTextBox
        // 
        ProductPriceTextBox.Location = new Point(221, 6);
        ProductPriceTextBox.Name = "ProductPriceTextBox";
        ProductPriceTextBox.Size = new Size(100, 23);
        ProductPriceTextBox.TabIndex = 1;
        // 
        // ProductNameTextBox
        // 
        ProductNameTextBox.Location = new Point(8, 6);
        ProductNameTextBox.Name = "ProductNameTextBox";
        ProductNameTextBox.Size = new Size(100, 23);
        ProductNameTextBox.TabIndex = 0;
        // 
        // BranchDetailsTab
        // 
        BranchDetailsTab.Controls.Add(ProductToAddComboBox);
        BranchDetailsTab.Controls.Add(BranchDetailsAddProductButton);
        BranchDetailsTab.Controls.Add(BranchDetailsDeleteButton);
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
        // ProductToAddComboBox
        // 
        ProductToAddComboBox.FormattingEnabled = true;
        ProductToAddComboBox.Location = new Point(222, 6);
        ProductToAddComboBox.Name = "ProductToAddComboBox";
        ProductToAddComboBox.Size = new Size(143, 23);
        ProductToAddComboBox.TabIndex = 4;
        ProductToAddComboBox.Text = "Select a new product...";
        // 
        // BranchDetailsAddProductButton
        // 
        BranchDetailsAddProductButton.Location = new Point(371, 6);
        BranchDetailsAddProductButton.Name = "BranchDetailsAddProductButton";
        BranchDetailsAddProductButton.Size = new Size(86, 23);
        BranchDetailsAddProductButton.TabIndex = 3;
        BranchDetailsAddProductButton.Text = "Add Product";
        BranchDetailsAddProductButton.UseVisualStyleBackColor = true;
        BranchDetailsAddProductButton.Click += BranchDetailsAddProductButton_Click;
        // 
        // BranchDetailsDeleteButton
        // 
        BranchDetailsDeleteButton.Location = new Point(130, 6);
        BranchDetailsDeleteButton.Name = "BranchDetailsDeleteButton";
        BranchDetailsDeleteButton.Size = new Size(75, 23);
        BranchDetailsDeleteButton.TabIndex = 2;
        BranchDetailsDeleteButton.Text = "Delete ";
        BranchDetailsDeleteButton.UseVisualStyleBackColor = true;
        BranchDetailsDeleteButton.Click += BranchDetailsDeleteButton_Click;
        // 
        // BranchDetailsDataGridView
        // 
        BranchDetailsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BranchDetailsDataGridView.Location = new Point(0, 35);
        BranchDetailsDataGridView.Name = "BranchDetailsDataGridView";
        BranchDetailsDataGridView.Size = new Size(785, 382);
        BranchDetailsDataGridView.TabIndex = 1;
        BranchDetailsDataGridView.CellContentClick += BranchDetailsDataGridView_CellContentClick;
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
    private Button EditBranchButton;
    private Button AddBranchButton;
    private DataGridView BranchDataGridView;
    private DateTimePicker BranchOpenDatePicker;
    private TextBox ProductPriceTextBox;
    private TextBox ProductNameTextBox;
    private Button DeleteProductButton;
    private Button EditProductButton;
    private Button AddProductButton;
    private DataGridView ProductDataGridView;
    private CheckBox WeightedItemCheckBox;
    private TabPage BranchDetailsTab;
    private DataGridView BranchDetailsDataGridView;
    private ComboBox BranchComboBox;
    private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    private Button BranchDetailsDeleteButton;
    private Button BranchDetailsAddProductButton;
    private ComboBox ProductToAddComboBox;
}
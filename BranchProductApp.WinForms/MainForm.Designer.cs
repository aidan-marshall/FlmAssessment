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
        tabControl1.SuspendLayout();
        BranchesTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)BranchDataGridView).BeginInit();
        ProductsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ProductDataGridView).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(BranchesTab);
        tabControl1.Controls.Add(ProductsTab);
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
}
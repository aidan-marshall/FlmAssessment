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
        tabPage2 = new TabPage();
        BranchNameTextBox = new TextBox();
        BranchTelephoneTextBox = new TextBox();
        BranchOpenDatePicker = new DateTimePicker();
        BranchDataGridView = new DataGridView();
        AddBranchButton = new Button();
        EditBranchButton = new Button();
        DeleteBranchButton = new Button();
        tabControl1.SuspendLayout();
        BranchesTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)BranchDataGridView).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(BranchesTab);
        tabControl1.Controls.Add(tabPage2);
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
        BranchesTab.Click += tabPage1_Click;
        // 
        // tabPage2
        // 
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(785, 417);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "tabPage2";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // BranchNameTextBox
        // 
        BranchNameTextBox.Location = new Point(6, 6);
        BranchNameTextBox.Name = "BranchNameTextBox";
        BranchNameTextBox.Size = new Size(100, 23);
        BranchNameTextBox.TabIndex = 0;
        BranchNameTextBox.TextChanged += textBox1_TextChanged_1;
        // 
        // BranchTelephoneTextBox
        // 
        BranchTelephoneTextBox.Location = new Point(112, 6);
        BranchTelephoneTextBox.Name = "BranchTelephoneTextBox";
        BranchTelephoneTextBox.Size = new Size(100, 23);
        BranchTelephoneTextBox.TabIndex = 1;
        // 
        // BranchOpenDatePicker
        // 
        BranchOpenDatePicker.Location = new Point(218, 6);
        BranchOpenDatePicker.Name = "BranchOpenDatePicker";
        BranchOpenDatePicker.Size = new Size(200, 23);
        BranchOpenDatePicker.TabIndex = 2;
        // 
        // BranchDataGridView
        // 
        BranchDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        BranchDataGridView.Location = new Point(218, 91);
        BranchDataGridView.Name = "BranchDataGridView";
        BranchDataGridView.Size = new Size(240, 150);
        BranchDataGridView.TabIndex = 3;
        // 
        // AddBranchButton
        // 
        AddBranchButton.Location = new Point(31, 317);
        AddBranchButton.Name = "AddBranchButton";
        AddBranchButton.Size = new Size(75, 23);
        AddBranchButton.TabIndex = 4;
        AddBranchButton.Text = "button1";
        AddBranchButton.UseVisualStyleBackColor = true;
        // 
        // EditBranchButton
        // 
        EditBranchButton.Location = new Point(112, 317);
        EditBranchButton.Name = "EditBranchButton";
        EditBranchButton.Size = new Size(75, 23);
        EditBranchButton.TabIndex = 5;
        EditBranchButton.Text = "button2";
        EditBranchButton.UseVisualStyleBackColor = true;
        // 
        // DeleteBranchButton
        // 
        DeleteBranchButton.Location = new Point(193, 317);
        DeleteBranchButton.Name = "DeleteBranchButton";
        DeleteBranchButton.Size = new Size(75, 23);
        DeleteBranchButton.TabIndex = 6;
        DeleteBranchButton.Text = "button3";
        DeleteBranchButton.UseVisualStyleBackColor = true;
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
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage BranchesTab;
    private TabPage tabPage2;
    private TextBox BranchTelephoneTextBox;
    private TextBox BranchNameTextBox;
    private Button DeleteBranchButton;
    private Button EditBranchButton;
    private Button AddBranchButton;
    private DataGridView BranchDataGridView;
    private DateTimePicker BranchOpenDatePicker;
}
using BranchProductApp.Core.Branches;
using BranchProductApp.Core.ProductBranchMappings;
using BranchProductApp.Core.Products;
using Microsoft.Extensions.Logging;

namespace BranchProductApp.WinForms;

public partial class MainForm : Form
{
    private readonly IBranchService branchService;
    private readonly IProductService productService;
    private readonly IProductBranchMappingService productBranchMappingService;
    private readonly ILogger<MainForm> logger;
    public MainForm(IBranchService BranchService, IProductService ProductService, IProductBranchMappingService ProductBranchMappingService, ILogger<MainForm> Logger)
    {
        InitializeComponent();
        this.branchService = BranchService;
        this.productService = ProductService;
        this.productBranchMappingService = ProductBranchMappingService;
        this.logger = Logger;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await LoadBranches();
        await LoadProducts();
        await InitializeBranchDetails();
    }

    private DialogResult ConfirmAction(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        return MessageBox.Show(message, title, buttons, icon);
    }

    private DialogResult ConfirmDelete()
    {
        return ConfirmAction("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    }

    private DialogResult ConfirmUpdate()
    {
        return ConfirmAction("Are you sure you want to update this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    private DialogResult ConfirmCreate()
    {
        return ConfirmAction("Are you sure you want to create this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
    }

    private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}
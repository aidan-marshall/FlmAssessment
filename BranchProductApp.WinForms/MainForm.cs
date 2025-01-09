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



}
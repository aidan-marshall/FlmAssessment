using BranchProductApp.Core.Services;

namespace BranchProductApp.WinForms;

public partial class MainForm : Form
{
    private readonly IBranchService branchService;
    private readonly IProductService productService;
    public MainForm(IBranchService branchService, IProductService productService)
    {
        InitializeComponent();
        this.branchService = branchService;
        this.productService = productService;
    }

    private async Task LoadBranches()
    {
        var branches = await branchService.GetAllBranchesAsync();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {

    }
}
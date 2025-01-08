using BranchProductApp.Core.Models;
using BranchProductApp.Core.Services;

namespace BranchProductApp.WinForms;

public partial class MainForm : Form
{
    private readonly IBranchService branchService;
    private readonly IProductService productService;
    private readonly IProductBranchMappingService productBranchMappingService;
    public MainForm(IBranchService BranchService, IProductService ProductService, IProductBranchMappingService ProductBranchMappingService)
    {
        InitializeComponent();
        this.branchService = BranchService;
        this.productService = ProductService;
        this.productBranchMappingService = ProductBranchMappingService;
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await LoadBranches();
        await LoadProducts();
    }

    private async Task LoadBranches()
    {
        var branches = await branchService.GetAllBranchesAsync();
        BranchDataGridView.DataSource = branches.ToList();
        BranchDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
        BranchComboBox.DataSource = branches.ToList();
        BranchComboBox.DisplayMember = "Name";
        BranchComboBox.ValueMember = "Id";
    }

    private async Task LoadProducts()
    {
        var products = await productService.GetProducts();
        ProductDataGridView.DataSource = products.ToList();
        ProductDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
    }

    private async void AddBranchButton_Click(object sender, EventArgs e)
    {
        var newBranch = new Branch
        {
            Name = BranchNameTextBox.Text,
            TelephoneNumber = BranchTelephoneTextBox.Text,
            OpenDate = BranchOpenDatePicker.Value
        };

        await branchService.CreateBranchAsync(newBranch);
        await LoadBranches();
    }

    private void BranchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var selectedBranch = BranchDataGridView.Rows[e.RowIndex].DataBoundItem as Branch;
            if (selectedBranch != null)
            {
                BranchNameTextBox.Text = selectedBranch.Name;
                BranchTelephoneTextBox.Text = selectedBranch.TelephoneNumber;
                BranchOpenDatePicker.Value = selectedBranch.OpenDate;
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
            await branchService.UpdateBranchAsync(selectedBranch);
            await LoadBranches();
        }
    }

    private async void DeleteBranchButton_Click(object sender, EventArgs e)
    {
        var selectedBranch = BranchDataGridView.CurrentRow?.DataBoundItem as Branch;

        if (selectedBranch != null)
        {
            await branchService.DeleteBranchAsync(selectedBranch.Id);
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

    private async void AddProductButton_Click(object sender, EventArgs e)
    {
        if (decimal.TryParse(ProductPriceTextBox.Text, out decimal price))
        {
            var newProduct = new Product
            {
                Name = ProductNameTextBox.Text,
                WeightedItem = WeightedItemCheckBox.Checked,
                SuggestedSellingPrice = price
            };

            await productService.CreateProduct(newProduct);
            await LoadProducts();
        }
        else
        {
            MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ProductDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var selectedProduct = ProductDataGridView.Rows[e.RowIndex].DataBoundItem as Product;
            if (selectedProduct != null)
            {
                ProductNameTextBox.Text = selectedProduct.Name;
                WeightedItemCheckBox.Checked = selectedProduct.WeightedItem;
                ProductPriceTextBox.Text = selectedProduct.SuggestedSellingPrice.ToString();
            }
        }
    }

    private async void EditProductButton_Click(object sender, EventArgs e)
    {
        var selectedProduct = ProductDataGridView.CurrentRow?.DataBoundItem as Product;

        if (selectedProduct != null)
        {
            selectedProduct.Name = ProductNameTextBox.Text;
            selectedProduct.WeightedItem = WeightedItemCheckBox.Checked;
            selectedProduct.SuggestedSellingPrice = decimal.Parse(ProductPriceTextBox.Text);

            await productService.UpdateProduct(selectedProduct);
            await LoadProducts();
        }
    }

    private async void DeleteProductButton_Click(object sender, EventArgs e)
    {
        var selectedProduct = ProductDataGridView.CurrentRow?.DataBoundItem as Product;
        if (selectedProduct != null)
        {
            await productService.DeleteProduct(selectedProduct.Id);
            await LoadProducts();
        }
    }

    private void WeightedItemCheckBox_CheckedChanged(object sender, EventArgs e)
    {

    }

    private async void BranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (BranchComboBox.SelectedValue != null)
        {
            if (BranchComboBox.SelectedValue is int selectedBranchId)
            {
                await LoadBranchProducts(selectedBranchId);
            }
        }
    }

    private async Task LoadBranchProducts(int selectedBranchId)
    {
        var branchProducts = await productBranchMappingService.GetProductsForBranch(selectedBranchId);
        var allProducts = await productService.GetProducts();
        var availableProducts = allProducts.Where(p => !branchProducts.Any(bp => bp.Id == p.Id)).ToList();

        BranchDetailsDataGridView.DataSource = branchProducts.ToList();
        BranchDetailsDataGridView.Columns["ProductBranchMappings"]!.Visible = false;
        ProductToAddComboBox.DataSource = availableProducts;
        ProductToAddComboBox.DisplayMember = "Name";
        ProductToAddComboBox.ValueMember = "Id";
    }

    private void BranchDetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private int GetSelectedBranchId()
    {
        if (BranchComboBox.SelectedValue == null)
        {
            MessageBox.Show("Please select a branch.", "No Branch Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return -1;
        }

        if (BranchComboBox.SelectedValue is int selectedBranchId)
        {
            return selectedBranchId;
        }

        return -1;
    }

    private async void BranchDetailsDeleteButton_Click(object sender, EventArgs e)
    {
        var selectedProduct = BranchDetailsDataGridView.CurrentRow?.DataBoundItem as Product;
        var selectedBranchId = GetSelectedBranchId();

        if (selectedProduct != null)
        {
            await productBranchMappingService.UnassignProductFromBranch(selectedBranchId, selectedProduct.Id);
            await LoadBranchProducts(selectedBranchId);
        }
    }

    private async void BranchDetailsAddProductButton_Click(object sender, EventArgs e)
    {
        if (BranchComboBox.SelectedValue is int selectedBranchId && ProductToAddComboBox.SelectedValue is int selectedProductId)
        {
            try
            {
                await productBranchMappingService.AssignProductToBranch(selectedBranchId, selectedProductId);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadBranchProducts(selectedBranchId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Please select a branch and a product.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
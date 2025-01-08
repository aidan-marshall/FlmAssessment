using BranchProductApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BranchProductApp.Core.Branches;
using BranchProductApp.Core.Products;
using BranchProductApp.Core.ProductBranchMappings;

namespace BranchProductApp.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        var services = new ServiceCollection();

        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("Server=localhost;Database=BranchProductDb2;Trusted_Connection=True;TrustServerCertificate=True")); 

        services.AddTransient<IBranchService, BranchService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductBranchMappingService, ProductBranchMappingService>();
        services.AddTransient<MainForm>();

        var serviceProvider = services.BuildServiceProvider();
        
        ApplicationConfiguration.Initialize();
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
}
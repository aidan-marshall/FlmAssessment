using BranchProductApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BranchProductApp.Core.Services;

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
        options.UseSqlServer("DefaultConnectionString"));

        services.AddTransient<IBranchService, BranchService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<MainForm>();

        var serviceProvider = services.BuildServiceProvider();
        
        ApplicationConfiguration.Initialize();
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
}
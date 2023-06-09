using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dotnet_Inventory_Manager.Models;

namespace Dotnet_Inventory_Manager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        InventoryDatabaseContext dbContext = new InventoryDatabaseContext();
        List<Inventory> inventory = dbContext.Inventories.ToList();
        return View(inventory);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

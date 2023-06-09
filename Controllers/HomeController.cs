using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dotnet_Inventory_Manager.Models;

namespace Dotnet_Inventory_Manager.Controllers;

public class HomeController : Controller
{
    InventoryDatabaseContext dbContext = new InventoryDatabaseContext();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(IFormCollection form)
    {
        Inventory inventory = new Inventory();

        inventory.ItemName = form["ItemName"];
        inventory.DatePurchased = Convert.ToDateTime(form["DatePurchased"]);
        inventory.Quality = form["Quality"];

        dbContext.Add(inventory);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        Inventory inventory = dbContext.Inventories.Find(id);
        return View(inventory);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection form)
    {
        Inventory inventory = dbContext.Inventories.Find(id);

        inventory.ItemName = form["ItemName"];
        inventory.DatePurchased = Convert.ToDateTime(form["DatePurchased"]);
        inventory.Quality = form["Quality"];

        dbContext.Entry(inventory).State = EntityState.Modified;
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        Inventory invId = dbContext.Inventories.Find(id);

        dbContext.Remove(invId);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

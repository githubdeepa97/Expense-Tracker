using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers;

public class ItemController : Controller
{
    private readonly ExpenseTrackerIdentityDbContext _context;
    public ItemController(ExpenseTrackerIdentityDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
         var item=await _context.Items.Include(x=>x.ItemGroup).ToListAsync();
        return View(item);
    }
    [HttpGet]
      public async Task<IActionResult> Create()
    {
        var itemGroup=await _context.ItemGroups.ToListAsync();
        return View(itemGroup);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
        return View();
    }
  
}
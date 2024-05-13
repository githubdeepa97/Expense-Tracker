using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers;

public class ItemGroupController : Controller
{
    private readonly ExpenseTrackerIdentityDbContext _context;
    public ItemGroupController(ExpenseTrackerIdentityDbContext context)
    {
        _context=context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var itemGroup= await _context.ItemGroups.ToListAsync();

        return View(itemGroup);
    }
    [HttpGet]
      public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
      public async Task<IActionResult> Create(ItemGroup ItemGroup)
    {
        await _context.ItemGroups.AddAsync(ItemGroup);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
     [HttpGet]
    [Authorize(Roles ="admin")]
      public async Task<IActionResult> Delete(int id)
    {
      var deleteData=await _context.ItemGroups.FindAsync(id);         
      if(deleteData!=null)
      {
        _context.ItemGroups.Remove(deleteData);
        _context.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  
  
}
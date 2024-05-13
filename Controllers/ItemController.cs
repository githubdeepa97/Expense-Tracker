using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers;
[Authorize(Roles = "admin")]
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
        ViewBag.itemGroup=new SelectList(await _context.ItemGroups.ToListAsync(),"Id","Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        await _context.Items.AddAsync(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
     [HttpGet]
    [Authorize(Roles ="admin")]
      public async Task<IActionResult> Delete(int id)
    {
      var deleteData=await _context.Items.FindAsync(id);         
      if(deleteData!=null)
      {
        _context.Items.Remove(deleteData);
        _context.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  
  
}
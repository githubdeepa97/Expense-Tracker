using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace ExpenseTracker.Controllers;

public class ExpenditureController : Controller
{
    private readonly ExpenseTrackerIdentityDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<ExpenditureController> _logger;
    public ExpenditureController(ExpenseTrackerIdentityDbContext context, ILogger<ExpenditureController> logger,UserManager<IdentityUser> userManager)
    {
        _context=context;
        _logger=logger;
        _userManager=userManager;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //  var item=await _context.Items.Include(x=>x.ItemGroup).ToListAsync();
        //  var user = await _userManager.GetUserAsync(User);
        // var expenditure= await _context.Expenditures.Include(a=>a.User).Include(x=>x.Item).ToListAsync();
         if (User.IsInRole("user"))
         {
          var user = await _userManager.GetUserAsync(User);

        var expenditures = await _context.Expenditures
        .Include(a => a.User)
        .Include(x => x.Item)
        .Where(e => e.UserId == user.Id)
        .ToListAsync();
         return View(expenditures);

    // Now 'expenditures' contains the expenditures associated with the logged-in user
        
         }
else
{
  var expenditure= await _context.Expenditures.Include(a=>a.User).Include(x=>x.Item).ToListAsync();
 return View(expenditure);
}  
       
    }
    [HttpGet]
      public async Task<IActionResult> Create()
    {
         ViewBag.items = new SelectList(_context.Items, "Id", "Name");
         if (User.IsInRole("user"))
         {
          var user = await _userManager.GetUserAsync(User);
          ViewBag.userid=user.Id;
          ViewBag.username=user.UserName;
         }else{
          ViewBag.users=new SelectList(_userManager.Users,"Id","UserName");
         }
         ViewBag.amount=await _context.Items.ToListAsync();
      return View();
    }
    [HttpPost]
      public async Task<IActionResult> Create(Expenditure expenditure)
    {
      if(expenditure.ItemId==null || expenditure.UserId==null || expenditure.Amount==null)
      {
          return View();
      }else{
        await _context.Expenditures.AddAsync(expenditure);
        await _context.SaveChangesAsync();
      }
        return RedirectToAction("Index");
    }
    // [HttpGet]
    //   public async Task<IActionResult> Edit(int id)
    // {
    //      ViewBag.items = new SelectList(_context.Items, "Id", "Name");
    //      if (User.IsInRole("user"))
    //      {
    //       var user = await _userManager.GetUserAsync(User);
    //       ViewBag.userid=user.Id;
    //       ViewBag.username=user.UserName;
    //      }else{
    //       ViewBag.users=new SelectList(_userManager.Users,"Id","UserName");
    //      }
    //      ViewBag.amount=await _context.Items.ToListAsync();
    //   return View();
    // }
    [HttpGet]
    [Authorize(Roles ="admin")]
      public async Task<IActionResult> Delete(int id)
    {
      var deleteData=await _context.Expenditures.FindAsync(id);         
      if(deleteData!=null)
      {
        _context.Expenditures.Remove(deleteData);
        _context.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  
}
using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace ExpenseTracker.Controllers;

public class ExpenditureController : Controller
{
    private readonly ExpenseTrackerIdentityDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<ExpenditureController> _logger;
    public ExpenditureController(ExpenseTrackerIdentityDbContext context, ILogger<ExpenditureController> logger)
    {
        _context=context;
        _logger=logger;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //  var item=await _context.Items.Include(x=>x.ItemGroup).ToListAsync();
        var expenditure= await _context.Expenditures.Include(x=>x.User).Include(x=>x.Item).ToListAsync();

        return View(expenditure);
    }
    [HttpGet]
      public async Task<IActionResult> Create()
    {
         ViewBag.items = new SelectList(_context.Items, "Id", "Name");
         ViewBag.users=new SelectList(_context.Users,"Id","Name");
         ViewBag.amount=await _context.Items.ToListAsync();
      return View();
    }
    [HttpPost]
      public async Task<IActionResult> Create(Expenditure expenditure)
    {
        await _context.Expenditures.AddAsync(expenditure);
        await _context.SaveChangesAsync();
        // _logger.LogInformation(expenditure.ToJson());

        return View();
    }
  
}
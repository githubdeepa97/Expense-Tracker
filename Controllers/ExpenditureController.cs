using ExpenseTracker.Areas.Identity.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace ExpenseTracker.Controllers;

public class ExpenditureController : Controller
{
    private readonly ExpenseTrackerIdentityDbContext _context;
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
        var Expenditure= await _context.Expenditures.ToListAsync();

        return View(Expenditure);
    }
    [HttpGet]
      public async Task<IActionResult> Create()
    {
        var items= await _context.Items.ToListAsync();
        var user= await _context.Users.ToListAsync();
        var expense = new Expense
        {
            items=new List<Item>(items),
            users=new List<User>(user)
        };
        return View(expense);
    }
    [HttpPost]
      public async Task<IActionResult> Create(Expenditure expenditure)
    {
        // await _context.Expenditures.AddAsync(expenditure);
        // await _context.SaveChangesAsync();
        _logger.LogInformation(expenditure.ToJson());

        return View();
    }
  
}
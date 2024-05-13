using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Areas.Identity.Data;

public class ExpenseTrackerIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public ExpenseTrackerIdentityDbContext(DbContextOptions<ExpenseTrackerIdentityDbContext> options)
        : base(options)
    {
    }
    public DbSet<Expenditure> Expenditures { get;set;}
    public DbSet<ItemGroup> ItemGroups { get;set;}
    public DbSet<Item> Items{ get;set;}
    // public DbSet<IdentityUser> Users { get;set;}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";
        var user = new IdentityRole("user");
        user.NormalizedName = "user";
        builder.Entity<IdentityRole>().HasData(admin,user);
        
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

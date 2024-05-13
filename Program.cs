using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExpenseTrackerIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ExpenseTrackerIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<ExpenseTrackerIdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ExpenseTrackerIdentityDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
// using (var scope = app.Services.CreateScope())
// {
//     var userManager=scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//     string email = "admin@gmail.com";
//     string password= "Test@123";

//     if(await userManager.FindByEmailAsync(email)==null)
//     {
//         var user = new IdentityUser();
//         user.UserName = email;
//         user.Email = email;

//         await userManager.CreateAsync(user,password);
//         await userManager.AddToRoleAsync(user,"admin");
//     }
// }
app.Run();

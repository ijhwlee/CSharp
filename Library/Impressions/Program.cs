using Impressions.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (System.Environment.MachineName == "HOME-201119")
{
  connectionString = builder.Configuration.GetConnectionString("HOME-201119Connection");
}
else if (System.Environment.MachineName == "LAPTOP-CMAETB3C")
{
  connectionString = builder.Configuration.GetConnectionString("LAPTOP-CMAETB3CConnection");
}
else if (System.Environment.MachineName == "LAPTOP-8N40M1AT")
{
  connectionString = builder.Configuration.GetConnectionString("LAPTOP-8N40M1ATConnection");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
  // Default Lockout settings.
  //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
  //options.Lockout.MaxFailedAccessAttempts = 5;
  //options.Lockout.AllowedForNewUsers = true;
  options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

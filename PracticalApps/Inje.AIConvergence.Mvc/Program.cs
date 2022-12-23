using Inje.AIConvergence.Mvc.Data;
using Inje.AIConvergence.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(name: "Inje.AIConvergence.WebApi",
  configureClient: options =>
  {
    options.BaseAddress = new Uri("https://localhost:5003/");
    options.DefaultRequestHeaders.Accept.Add(
      new MediaTypeWithQualityHeaderValue("application/json", 1.0));
  });
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindHOME-201119");
if (System.Environment.MachineName == "HOME-201119")
{
  connectionString = builder.Configuration.GetConnectionString("DefaultHOME-201119");
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindHOME-201119");
}
else if (System.Environment.MachineName == "LAPTOP-CMAETB3C")
{
  connectionString = builder.Configuration.GetConnectionString("DefaultLaptop");
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindLaptop");
}
else if (System.Environment.MachineName == "LAPTOP-8N40M1AT")
{
  connectionString = builder.Configuration.GetConnectionString("DefaultOdyssey");
  connectionNorthwind = builder.Configuration.GetConnectionString("NorthwindOdyssey");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddNorthwindContext(connectionNorthwind);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

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

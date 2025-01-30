using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RezerwacjaSamochodow.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodawanie us³ug do kontenera
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Konfiguracja middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
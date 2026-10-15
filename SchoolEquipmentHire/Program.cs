
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolEquipmentHire.Data;
using Microsoft.AspNetCore.Identity;
using SchoolEquipmentHire.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolEquipmentContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolEquipmentContext")
        ?? throw new InvalidOperationException(
            "Connection string 'SchoolEquipmentContext' not found.")));

builder.Services
    .AddDefaultIdentity<AppUser>(options =>
        options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SchoolEquipmentContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Initialise the database and seed data.
using (var scope = app.Services.CreateScope())
{

    var adminEmail = "admin@school.nz";
    var adminPassword = "Admin@123!";

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SchoolEquipmentContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

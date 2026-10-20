
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using SchoolEquipmentHire.Data;
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

// Initialise the database, seed data and create the admin account.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolEquipmentContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(services);

    var userManager =
        services.GetRequiredService<UserManager<AppUser>>();

    var roleManager =
        services.GetRequiredService<RoleManager<IdentityRole>>();

    // Create roles if they do not exist.
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("Student"))
    {
        await roleManager.CreateAsync(new IdentityRole("Student"));
    }

    // Admin login credentials.
    var adminEmail = "admin@school.nz";
    var adminPassword = "Admin@123!";

    var admin = await userManager.FindByEmailAsync(adminEmail);

    // Create the admin account automatically.
    if (admin == null)
    {
        admin = new AppUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true,

            FirstName = "System",
            LastName = "Administrator",
            Role = RoleType.Admin,
            YearLevel = 13
        };

        var result = await userManager.CreateAsync(
            admin, adminPassword);

        if (!result.Succeeded)
        {
            throw new Exception(
                "Failed to create admin account: " +
                string.Join("; ",
                    result.Errors.Select(e => e.Description)));
        }
    }

    // Ensure the admin has the actual Identity Admin role.
    if (!await userManager.IsInRoleAsync(admin, "Admin"))
    {
        var roleResult = await userManager.AddToRoleAsync(
            admin, "Admin");

        if (!roleResult.Succeeded)
        {
            throw new Exception(
                "Failed to assign Admin role: " +
                string.Join("; ",
                    roleResult.Errors.Select(e => e.Description)));
        }
    }
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

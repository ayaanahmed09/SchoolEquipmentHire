using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolEquipmentHire.Data;
using Microsoft.AspNetCore.Identity;
using SchoolEquipmentHire.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SchoolEquipmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolEquipmentContext") ?? throw new InvalidOperationException("Connection string 'SchoolEquipmentContext' not found.")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<SchoolEquipmentContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SchoolEquipmentContext>();
    context.Database.EnsureCreated();

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

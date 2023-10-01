using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Models;
using Shopping.Repository.Class;
using Shopping.Repository.Interface;
using Shopping.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    // Configure Identity options as needed
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders(); //  to configure default token providers for password reset,email verification etc.

// Register to send email
var emailModel = builder.Configuration.GetSection("EmailModel").Get<EmailModel>();

if (emailModel != null)
{
    // Register the EmailModel as a singleton service
    builder.Services.AddSingleton(emailModel);
}
else
{
 
    // Handle the case where emailModel is null, e.g., by logging an error
}
//Add services
builder.Services.AddScoped<IEmailServicesRepo, EmailServicesRepo>();

builder.Services.AddControllersWithViews();

// GEnericRepository 
builder.Services.AddScoped<IUnitOfWorkRepo, UnitOfWorkRepo>();
builder.Services.AddRazorPages();



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
    pattern: "{controller=Location}/{action=LocationIndex}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
//    var roles = new[] { "Admin", "Customer" };
//    foreach (var roleName in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(roleName))
//        {
//            var role = new ApplicationRole(roleName);
//            var result = await roleManager.CreateAsync(role);

//            if (!result.Succeeded)
//            {
//                // Handle role creation errors, if necessary
//            }
//        }
//    }
//}
app.MapRazorPages();

app.Run();

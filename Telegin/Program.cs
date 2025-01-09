using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Telegin.Data;
using Telegin.UI.Models;
using Telegin.UI.Data;


var builder = WebApplication.CreateBuilder(args);


////������ ����� �������, ���������� ������� ������� � �.�.
///настроики пороля;
builder.Services.AddDefaultIdentity<LocalUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<ApplicationDbContext>();

//// ��������� �������� ����������� � ��������, ��� ����������� �role� ����� �������� �admin�
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", police =>
    police.RequireRole( "admin"));
});

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmailSender, NoOpEmailSender>();
//builder.Logging.AddFile("Logs/app-{Date}.txt");

// ����������� NoOpEmailSender � �������� IEmailSender



// Add services to the container.                                                                               
var connectionString = builder.Configuration.GetConnectionString("SqLiteConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

//builder.Services.AddDefaultIdentity<LocalUser>()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<SignInManager<LocalUser>>(); 
builder.Services.AddScoped<UserManager<LocalUser>>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

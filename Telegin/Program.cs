using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Telegin.Data;
using Telegin.UI.Data;

var builder = WebApplication.CreateBuilder(args);

//������ ����� �������, ���������� ������� ������� � �.�.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{   options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false; 
    options.Password.RequireUppercase = false; 
    options.Password.RequireNonAlphanumeric = false; 
    options.Password.RequiredLength = 1; }).AddEntityFrameworkStores<ApplicationDbContext>();


var userName = builder.Configuration["UserData:UserName"];
var userData = builder.Configuration.GetSection("UserData").Get<UserData>();

// Add services to the container.                                                                               
var connectionString = builder.Configuration.GetConnectionString("SqLiteConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

public class UserData
{
    public string UserName { get; set; }
    public int PageSize { get; set; }
}




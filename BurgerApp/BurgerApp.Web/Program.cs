using BurgerApp.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = "/Users/Login";
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10); // ako ne e prisuten 10 min kaj nas na stranata da se prenasovi pak da se logira
});

builder.Services.AddAuthorization();


#region Configurating Serilog
var loggerConfiq = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Host.UseSerilog((context, confiq) =>
{
    confiq.ReadFrom.Configuration(loggerConfiq);
});
//builder.Logging.AddSerilog();
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(configuration)
//    .CreateLogger();
#endregion


// Dependency Injection
string connectionString = builder.Configuration.GetConnectionString("BurgerAppDbConnection");
builder.Services.InjectDbContext(connectionString);
builder.Services.InjectAutoMapper();
builder.Services.InjectRepositories();
builder.Services.InjectServices();

var app = builder.Build();
Log.Information("Application Starting Up");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSerilogRequestLogging(); // loggs every request

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapAreaControllerRoute()
//});
//TODO Please help me

app.Run();

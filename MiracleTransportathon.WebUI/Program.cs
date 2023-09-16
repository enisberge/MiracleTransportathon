using EnisBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.BusinessLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.WebUI.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserHelper>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(40); // Oturum zaman aþýmý
    options.Cookie.HttpOnly = true;
});
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<User,Role>().AddEntityFrameworkStores<Context>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Account/Login/";
                   options.LogoutPath = "/Account/Login/";
                   options.AccessDeniedPath = "/Account/Login/";
                   options.Cookie.Name = "MiracleTransportathon";
               });

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama middleware'ini etkinleþtirin
app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

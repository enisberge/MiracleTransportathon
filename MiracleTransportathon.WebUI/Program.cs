using Microsoft.EntityFrameworkCore;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<User,Role>().AddEntityFrameworkStores<Context>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

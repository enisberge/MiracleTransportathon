using EnisBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.BusinessLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.EntityFramework;
using MiracleTransportathon.EntityLayer.Concrete;
using MiracleTransportathon.WebApi.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IVehicleDal, EfVehicleDal>();
builder.Services.AddScoped<IVehicleService, VehicleManager>();
builder.Services.AddScoped<IRequestDal, EfRequestDal>();
builder.Services.AddScoped<IRequestService, RequestManager>();
builder.Services.AddScoped<ICompanyDal, EfCompanyDal>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<ICompanyDal, EfCompanyDal>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<ICityDal, EfCityDal>();
builder.Services.AddScoped<ICityService, CityManager>();
builder.Services.AddScoped<IOfferDal, EfOfferDal>();
builder.Services.AddScoped<IOfferService, OfferManager>();
builder.Services.AddScoped<UserHelper>();


builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

//builder.Services.AddScoped
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
//apiyi dýþarýya açma
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MiracleTransportathon", opts =>
    {
        opts.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(40); // Oturum zaman aþýmý
    options.Cookie.HttpOnly = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Home/Index/";
                   options.LogoutPath = "/Home/Index/";
                   options.AccessDeniedPath = "/Home/Index/";
                   options.Cookie.Name = "MiracleTransportathon";
               });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MiracleTransportathon");
app.UseAuthentication(); // Kimlik doðrulama middleware'ini etkinleþtirin
app.UseAuthorization();



app.MapControllers();

app.Run();



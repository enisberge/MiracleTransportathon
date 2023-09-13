using EnisBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.BusinessLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;

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


//builder.Services.AddScoped
builder.Services.AddAutoMapper(typeof(Program));

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
app.UseAuthorization();

app.MapControllers();

app.Run();

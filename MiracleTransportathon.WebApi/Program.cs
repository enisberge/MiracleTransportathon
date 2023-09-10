using EnisBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.BusinessLayer.Concrete;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IUserDal,EfUserDal>();
builder.Services.AddScoped<IUserService,UserManager>();
builder.Services.AddScoped<IVehicleDal, EfVehicleDal>();
builder.Services.AddScoped<IVehicleService, VehicleManager>();

//builder.Services.AddScoped
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
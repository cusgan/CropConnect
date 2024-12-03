using CropConnect;
using CropConnect.Repositories;
using CropConnect.Repositories.Interfaces;
using CropConnect.Services;
using CropConnect.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
//using MySqlConnector;
//using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IGuideService, GuideService>();
builder.Services.AddScoped<IGuideRepository, GuideRepository>();

builder.Services.AddDbContext<AppDbContext>(
    db => db.UseMySQL(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Scoped
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
//builder.Services.AddSingleton<IDbConnection>(sp =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("Default")!;
//    return new MySqlConnector.MySqlConnection(connectionString);
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

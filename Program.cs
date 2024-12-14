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
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IFarmService, FarmService>();
builder.Services.AddTransient<IGuideService, GuideService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IPostingService, PostingService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IGuideRepository, GuideRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IPostingRepository, PostingRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Allows all origins
              .AllowAnyMethod() // Allows all HTTP methods
              .AllowAnyHeader(); // Allows all headers
    });
});

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

// Server STATIC files for HTML files in .CLIENT
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(),"_CLIENT")),
    //RequestPath = "/client"
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Foodapi.Data;
using Foodapi.Services;
using Foodapi.Mappings;
using Foodapi.Middleware;
using Foodapi.Validators;

var projectRoot = Directory.GetCurrentDirectory();
var webRoot = Path.Combine(projectRoot, "wwwroot");
if (!Directory.Exists(webRoot))
{
    Directory.CreateDirectory(webRoot);
}

var builder = WebApplication.CreateBuilder(args);



// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserProfileDtoValidator>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Food API", Version = "v1" });
});

var app = builder.Build();

// Test database connection
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        var canConnect = await context.Database.CanConnectAsync();
        Console.WriteLine($"Database connection: {(canConnect ? "Success" : "Failed")}");
        if (canConnect)
        {
            var userCount = await context.Users.CountAsync();
            Console.WriteLine($"Users in database: {userCount}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database error: {ex.Message}");
    }
}

// Configure the HTTP request pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");



app.MapControllers();

app.Run();
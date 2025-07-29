using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using DashboardApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add controller support 
builder.Services.AddControllers();

// Enable CORS to allow requests from Angular 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add Swagger/OpenAPI support for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable the defined CORS policy
app.UseCors("AllowAngularApp");

// Enable Authorization 
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

app.Run();

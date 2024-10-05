using Microsoft.EntityFrameworkCore;
using ProductService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); // Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseSwagger(); // Add this line
app.UseSwaggerUI(c => // Add this line
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Service API V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.MapControllers();
app.Run();

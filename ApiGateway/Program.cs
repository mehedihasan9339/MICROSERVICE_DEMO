using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot configuration from JSON file
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Add Ocelot services
builder.Services.AddOcelot(builder.Configuration);


builder.Services.AddCustomJwtAuthentication();

// Configure Swagger
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });
});

builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.UseRouting();

// Enable Ocelot Middleware
await app.UseOcelot();


app.UseAuthentication();
app.UseAuthorization();

app.Run();

using Microsoft.Extensions.Configuration;
using Solution.Utilities.Implementations;
using Solution.Utilities.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITriangleService, TriangleService>();
builder.Services.AddSingleton<ICoordinateService, CoordinateService>();

var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var corsSettings = configuration.GetSection("CorsSettings");

var section = corsSettings.GetSection("AllowedOrigin");

var allowedOrigin = section.Get<string[]>();

if (allowedOrigin != null)
{
    app.UseCors(options => options.WithOrigins(allowedOrigin)
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials()
                                                );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

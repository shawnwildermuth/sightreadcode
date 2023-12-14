using Microsoft.EntityFrameworkCore;
using SightReadCode.Api.Data;
using WilderMinds.MinimalApiDiscovery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SightReadingContext>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapApis();

app.MapFallbackToFile("/index.html");

app.Run();


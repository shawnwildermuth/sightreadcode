using Microsoft.EntityFrameworkCore;
using SightReadCode.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SightReadingContext>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/getcode", async (SightReadingContext ctx) =>
{
  var results = await ctx.CodeBlocks.ToListAsync();
  return Results.Ok(results);
});

app.MapFallbackToFile("/index.html");

app.Run();


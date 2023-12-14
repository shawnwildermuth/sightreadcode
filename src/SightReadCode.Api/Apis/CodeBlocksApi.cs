using Microsoft.EntityFrameworkCore;
using SightReadCode.Api.Data;
using SightReadCode.Api.Data.Entities;
using WilderMinds.MinimalApiDiscovery;

namespace SightReadCode.Api.Apis;

public class CodeBlocksApi : IApi
{
  public void Register(IEndpointRouteBuilder builder)
  {
    var grp = builder.MapGroup("/api/codeblocks");

    grp.MapGet("", GetAll);
    grp.MapGet("{id:int}", GetOne);
    grp.MapGet("random", GetRandom);
    grp.MapPost("", Create);
  }

  public static async Task<IResult> Create(SightReadingContext ctx, CodeBlock model)
  {
    ctx.CodeBlocks.Add(model);

    if (await ctx.SaveChangesAsync() > 0)
    {
      return Results.Created($"/api/codeblocks/{model.Id}", model);
    }

    return Results.Problem("Could not save CodeBlock");
  }

  public static async Task<IResult> GetRandom(SightReadingContext ctx)
  {
    var result = await ctx.CodeBlocks
      .OrderBy(c => new Guid())
      .FirstAsync();

    return Results.Ok(result);
  }

  public static async Task<IResult> GetOne(SightReadingContext ctx, int id)
  {
    var result = await ctx.CodeBlocks.FindAsync(id);
    if (result is null) return Results.NotFound();
    return Results.Ok(result);
  }

  public static async Task<IResult> GetAll(SightReadingContext ctx)
  {
    return Results.Ok(await ctx.CodeBlocks.ToListAsync());
  }
}

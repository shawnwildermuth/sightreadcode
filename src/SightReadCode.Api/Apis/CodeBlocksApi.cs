using Mapster;
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
    grp.MapPut("{id:int}", Update);
    grp.MapDelete("{id:int}", Delete);
  }

  public static async Task<IResult> Delete(SightReadingContext ctx, int id)
  {
    if (await ctx.CodeBlocks
                 .Where(c => c.Id == id)
                 .ExecuteDeleteAsync() > 0)
    {
      return Results.Ok();
    }

    return Results.Problem("Could not delete code block.");
  }

  public static async Task<IResult> Update(SightReadingContext ctx, int id, CodeBlock model)
  {
    var old = await ctx.CodeBlocks.FindAsync(id);
    if (old is null)
    {
      return Results.NotFound("No code block found.");
    }

    model.Adapt(old);

    if (await ctx.SaveChangesAsync() > 0)
    {
      return Results.Ok(old);
    }
    else
    {
      return Results.Problem("No changes detected.");
    }
      
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
    var random = new Random();

    var result = await ctx.CodeBlocks
      .ElementAtAsync(random.Next(0, ctx.CodeBlocks.Count()));

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

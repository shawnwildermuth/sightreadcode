using Microsoft.EntityFrameworkCore;
using SightReadCode.Api.Data.Entities;

namespace SightReadCode.Api.Data;

public class SightReadingContext : DbContext
{
  private readonly IConfiguration _config;

  public SightReadingContext(DbContextOptions<SightReadingContext> opt, 
    IConfiguration config) 
    : base(opt)
	{
    _config = config;
  }

	public DbSet<CodeBlock> CodeBlocks  => Set<CodeBlock>();
  public DbSet<Answer> Answers => Set<Answer>();
  public DbSet<Response> Responses => Set<Response>();
  public DbSet<ReadFlag> ReadFlags => Set<ReadFlag>();
  public DbSet<Reaction> Reactions => Set<Reaction>();

  protected override void OnConfiguring(DbContextOptionsBuilder bldr)
  {
    base.OnConfiguring(bldr);

    var connectionString = _config.GetConnectionString("SightReadingDb");
    bldr.UseSqlServer(connectionString);
  }

  protected override void OnModelCreating(ModelBuilder bldr)
  {
    base.OnModelCreating(bldr);

    bldr.Entity<CodeBlock>()
      .HasData(new List<CodeBlock>()
      {
        new CodeBlock() 
        {
          Id = 1,
           TheCode = """
           public static class Program
           {
              public static int Main(object[] args)
              {
                return -1;
              }
           }
           """,
           Title = "Sample Code Block",
           LanguageCode = "cs"
        }
      });

  }
}

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

  protected override void OnConfiguring(DbContextOptionsBuilder bldr)
  {
    base.OnConfiguring(bldr);

    var connectionString = _config.GetConnectionString("SightReadingDb");
    bldr.UseSqlServer(connectionString);


  }
}

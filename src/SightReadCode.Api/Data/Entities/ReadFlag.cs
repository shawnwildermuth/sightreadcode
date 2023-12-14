namespace SightReadCode.Api.Data.Entities;

public class ReadFlag
{
  public int Id { get; set; }
  public required string UserId { get; set; } = "";
  public bool HasRead { get; set; }
  public int TargetId { get; set; }
  public required string TargetType { get; set; }

}

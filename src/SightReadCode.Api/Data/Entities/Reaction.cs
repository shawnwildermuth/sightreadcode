namespace SightReadCode.Api.Data.Entities;

public class Reaction
{
  public int Id { get; set; }
  public required string UserId { get; set; } = "";
  public required string ReactionIcon { get; set; }
  public int TargetId { get; set; }
  public required string TargetType { get; set; }
}

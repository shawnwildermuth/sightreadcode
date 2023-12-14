namespace SightReadCode.Api.Data.Entities;

public class Response
{
  public int Id { get; set; }
  public required string UserId { get; set; } = "";
  public required string ResponseText { get; set; }
  public int AnswerId { get; set; }
  public virtual required Answer Answer { get; set; }
}
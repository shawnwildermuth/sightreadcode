namespace SightReadCode.Api.Data.Entities;

public class Answer
{
  public int Id { get; set; }
  public required string UserId { get; set; } = "";
  public required string AnswerText { get; set; }
  public int CodeBlockId { get; set; }
  public virtual required CodeBlock CodeBlock {get;set;}
  public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
}

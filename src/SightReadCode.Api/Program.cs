var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/api/getcode", () =>
{
  return """
    function foo() {
      console.write("foo");
    }
  """;
});

app.Run();


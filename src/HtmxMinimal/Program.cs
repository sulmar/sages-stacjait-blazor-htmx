using HtmxMinimal.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents();
var app = builder.Build();

// Udostępnie plików statycznych z katalogu wwwroot
app.UseStaticFiles();

app.MapGet("/time", () =>
{
    var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    
    return $"<p>Aktualny czas: {now}</p>";
});

app.MapGet("/lazy", (string email, string firstname, int userid) =>
{
    return $"<p>Dane {userid} {email} {firstname} zostały załadowane dopiero gdy przewinąłeś stronę</p>";
});

app.MapPost("/hello", ([FromForm] HelloForm model) =>
{
    string message = $"Hello, {model.Name} #{model.UserId}!";
    
    return new RazorComponentResult<HelloComponent>( new { Message = message } );
}).DisableAntiforgery();

// Ustawienie index.html jako strony głównej
app.MapFallbackToFile("index.html");

app.Run();


public class HelloForm
{
    public int UserId { get; set; }
    public string Name { get; set; }
    
}
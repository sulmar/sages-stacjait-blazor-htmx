var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Udostępnie plików statycznych z katalogu wwwroot
app.UseStaticFiles();

app.MapGet("/time", () =>
{
    var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    
    return $"<p>Aktualny czas: {now}</p>";
});

// Ustawienie index.html jako strony głównej
app.MapFallbackToFile("index.html");

app.Run();

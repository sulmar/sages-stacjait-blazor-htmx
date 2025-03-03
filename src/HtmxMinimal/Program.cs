var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Udostępnie plików statycznych z katalogu wwwroot
app.UseStaticFiles();

// Ustawienie index.html jako strony głównej
app.MapFallbackToFile("index.html");

app.Run();

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});

var app = builder.Build();

app.UseStaticFiles(); // Permite servir imágenes y otros archivos estáticos

app.MapGet("/", async (context) =>
{
    string html = @"
        <!DOCTYPE html>
        <html lang='es'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Historia de un Gato</title>
            <style>
                body { font-family: Arial, sans-serif; text-align: center; background-color: #f4f4f4; }
                h1 { color: #333; }
                p { max-width: 600px; margin: auto; font-size: 18px; }
                img { width: 300px; border-radius: 10px; }
            </style>
        </head>
        <body>
            <h1>Historia de un Gato</h1>
            <img src='/images/gato.jpg' alt='Un gato adorable'>
            <p>Este es un gato que un día decidió emprender una aventura. Desde entonces, ha explorado mundos desconocidos, saltando de techo en techo y conquistando corazones con su ternura.</p>
        </body>
        </html>";

    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(html);
});

app.Run();

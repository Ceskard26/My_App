using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la aplicación
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger SIEMPRE (No solo en desarrollo)
app.UseSwagger();
app.UseSwaggerUI();

// Configurar la redirección HTTPS
app.UseHttpsRedirection();

// Endpoint de prueba
app.MapGet("/", () => "Hello, World!");

app.Run();

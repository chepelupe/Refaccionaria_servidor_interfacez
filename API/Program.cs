using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<infraestructura.RefaccionariaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionAzure"),
sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.EnableRetryOnFailure(
    maxRetryCount: 5,
    maxRetryDelay: TimeSpan.FromSeconds(30),
    errorNumbersToAdd: null);
}));

// Add services to the container.
builder.Services.AddControllers();

//Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirDesarrolloWeb", policy =>
    {
        policy.AllowAnyOrigin()    // Permite que se conecte el React/Angular/HTML de tu compañero
              .AllowAnyHeader()    // Permite que envíe JSON
              .AllowAnyMethod();   // Permite GET, POST, PUT, DELETE
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ¡AQUÍ ESTÁ EL CAMBIO! CORS debe ir ANTES de la autorización.
app.UseCors("PermitirDesarrolloWeb");

app.UseAuthorization();

app.MapControllers();

// Solo un Run() al final para arrancar el servidor.
app.Run();
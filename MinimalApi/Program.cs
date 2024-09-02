


using Microsoft.AspNetCore.Cors;
var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration.GetValue<string>("allowedOriginsConfig")!;

//services
builder.Services.AddCors(possibleOption =>
{
    possibleOption.AddPolicy("allowedOriginsPolicy", settings =>
    {
        settings.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });

    possibleOption.AddPolicy("allPolicy", settings =>
    {
        settings.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.useOutputCache();

var app = builder.Build();
//middlewares

app.UseCors();

app.MapGet("/", [EnableCors(policyName: "allowedOriginsPolicy")]() => "Hello World!");

app.MapGet("/test", [EnableCors(policyName: "allowedOriginsPolicy")]() => "you are clearly receiving this text");

app.MapGet("/generos"), () =>
{
    new Genero 
    {
        Id = 1,
        Nombre = "Drama"
    },
    new Genero
    {
        Id = 2,
        Nombre = "Accion"
    },
    new Genero
    {
        Id = 3,
        Nombre = "Comedia"
    },
}


app.Run();

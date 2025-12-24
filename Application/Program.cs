using Application.Config;
using Infraestructure.Extension;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Configuration
    .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"Config/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.AddSQLConnection();
builder.AgregarCola();

var app = builder.Build();


app.MapGet("/person/{id}", async Task<IResult>(int id, PersonService personService) =>
{
    //Este try catch es solo para demostrar el manejo de errores y respuestas HTTP adecuadas, se implementara filtro de excepciones en el futuro
    try
    {
        var person = await personService.GetPersonById(id);
        return Results.Ok(person);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound(new { mensaje = $"La persona con id {id} no existe" });
    }
    catch (Exception ex)
    {
        return Results.Problem(detail: ex.Message);
    }
});

app.Run();

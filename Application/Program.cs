using Infraestructure.Extension;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.AddSQLConnection();
builder.AgregarCola();

var app = builder.Build();


app.MapGet("/person/{id}", (int id, PersonService personService) =>
{
    var person = personService.GetPersonById(id);
    return Results.Ok(person);
});

app.Run();

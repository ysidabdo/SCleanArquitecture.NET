namespace Infraestructure.DBRepositories;
public record PersonDbEntity
{
    public int Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public int Age { get; init; }

}

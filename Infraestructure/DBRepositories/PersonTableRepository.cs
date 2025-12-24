using System.Data;
using Dapper;
using Infraestructure.DBRepositories;

public class PersonTableRepository
{
    private readonly Func<IDbConnection> _connectionFactory;

    public PersonTableRepository(Func<IDbConnection> connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public virtual async Task<IEnumerable<PersonDbEntity>> GetAllPersonsWhere(string whereClause)
    {
        var sql = $"SELECT Id, FirstName, LastName, Age FROM persons WHERE {whereClause}";
        using var connection = _connectionFactory();
        connection.Open();
        return await connection.QueryAsync<PersonDbEntity>(sql);
    }
}
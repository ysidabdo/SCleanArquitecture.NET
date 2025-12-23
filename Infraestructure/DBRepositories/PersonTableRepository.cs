
using Microsoft.Data.SqlClient;

public  class PersonTableRepository
{

    private readonly string _connectionString;

    public PersonTableRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public virtual dynamic GetAllPersonsWhere(string whereClause)
    {
        var sql = "SELECT top(10) * FROM persons where  " + whereClause;
        var persons = new List<dynamic>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var person = new
                        {
                            PersonID = reader.GetInt32(reader.GetOrdinal("PersonID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"))
                        };
                        persons.Add(person);
                    }
                }
            }
        }
        return persons;
    }
}
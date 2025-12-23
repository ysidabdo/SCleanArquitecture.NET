public static class DbConfig
{
    public static void AddSQLConnection (this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddTransient(_ => new PersonTableRepository(connectionString));
    }


}
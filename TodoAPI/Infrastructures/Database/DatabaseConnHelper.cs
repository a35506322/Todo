namespace Todo.API.Infrastructures.Database;

public class DatabaseConnHelper
{
    private readonly IConfiguration _configuration;

    public DatabaseConnHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection TodoConnection() => new SqlConnection(_configuration.GetConnectionString("Todo"));
}

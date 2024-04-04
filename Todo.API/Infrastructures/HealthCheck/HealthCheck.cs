namespace Todo.API.Infrastructures.HealthCheck;

public static class HealthCheck
{
    public static void HealthCheckConfig(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddHealthChecks()
                    .AddSqlServer(
                        connectionString: configuration.GetConnectionString("Todo"),
                        healthQuery: "SELECT 1;",
                        name: "sql",
                        failureStatus: HealthStatus.Degraded,
                        tags: new string[] { "db", "sql", "sqlserver" });
    }
}

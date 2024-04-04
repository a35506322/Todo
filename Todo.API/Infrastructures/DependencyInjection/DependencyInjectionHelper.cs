namespace Todo.API.Infrastructures.DependencyInjection;

public static class DependencyInjectionHelper
{
    public static void DIConfigurator(this IServiceCollection services)
    {

        // service
        services.AddScoped<ITodoService, TodoService>();


        // repository
        services.AddScoped<ITodoRepository, TodoRepository>();

        // other
        services.AddScoped<JWTHelper>();
        services.AddScoped<DatabaseConnHelper>();
    }
}

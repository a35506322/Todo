namespace Todo.API.Infrastructures.DependencyInjection;

public static class DependencyInjectionHelper
{
    public static void DIConfigurator(this IServiceCollection services)
    {
        services.AddScoped<JWTHelper>();
    }
}

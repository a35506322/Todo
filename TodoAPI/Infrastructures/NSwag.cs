namespace TodoAPI.Infrastructures;

public static class NSwag
{
    public static void NSwagConfigSetting(this IServiceCollection services)
    {
        services.AddOpenApiDocument(
        (settings, provider) =>
        {
            settings.Title = "Todo API";
            settings.Version = "v1";
        });
    }
}

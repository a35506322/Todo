var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var env = builder.Environment;
SerilLogHelper.ConfigureSerilLogger(config);

try
{
    // Add services to the container.
    builder.Services.AddControllers().AddNewtonsoftJson();

    // Serillog 
    builder.Services.AddSerilog();

    // add OpenAPI v3 document
    // https://github.com/vaclavnovotny/NSwag.Examples
    builder.Services.AddExampleProviders(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.NSwagConfigSetting(env);

    // DI
    builder.Services.DIConfigurator();

    // Atuh
    builder.Services.AddAuthorization();

    // AutoMapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Error Handler
    // https://www.milanjovanovic.tech/blog/global-error-handling-in-aspnetcore-8?utm_source=YouTube&utm_medium=social&utm_campaign=25.03.2024#configuring-iexceptionhandler-implementations
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();

    // JWT
    builder.Services.JWTConfigurator(config);

    builder.Services.HealthCheckConfig(config);

    builder.Services.CorsSetting(env);

    var app = builder.Build();

    // serve OpenAPI/Swagger documents
    app.UseOpenApi();
    // serve Swagger UI
    app.UseSwaggerUi();
    // serve ReDoc UI
    app.UseReDoc((config) => config.Path = "/redoc");

    // Logging
    // https://stackoverflow.com/questions/60076922/serilog-logging-web-api-methods-adding-context-properties-inside-middleware
    app.UseMiddleware<RequestResponseLoggingMiddleware>();
    app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = SerilLogHelper.EnrichFromRequest);
    app.UseExceptionHandler();

    app.UseHttpsRedirection();

    app.UseCors();

    // 先驗證再授權
    app.UseAuthentication();
    app.UseAuthorization();

    // Configure the HTTP request pipeline.
    app.MapHealthChecks("/healthz", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteResponse
    });

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


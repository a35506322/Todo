var builder = WebApplication.CreateBuilder(args);

SerilLogHelper.ConfigureSerilLogger(builder.Configuration);

try
{
    // Add services to the container.

    builder.Services.AddControllers();

    // serillog 
    builder.Services.AddSerilog();

    // add OpenAPI v3 document
    builder.Services.NSwagConfigSetting();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    // Logging
    // https://stackoverflow.com/questions/60076922/serilog-logging-web-api-methods-adding-context-properties-inside-middleware
    app.UseMiddleware<RequestResponseLoggingMiddleware>();
    app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = SerilLogHelper.EnrichFromRequest);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    // serve OpenAPI/Swagger documents
    app.UseOpenApi();
    // serve Swagger UI
    app.UseSwaggerUi();
    // serve ReDoc UI
    app.UseReDoc();

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


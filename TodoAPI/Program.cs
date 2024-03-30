

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// add OpenAPI v3 document
builder.Services.NSwagConfigSetting();

var app = builder.Build();

// Configure the HTTP request pipeline.

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

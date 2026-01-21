using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);//automatically find and register all of the handlers(IRequestHandler etc)
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));//for all types of commands and queries(=ValidationBehavior<TRequest, TResponse>)
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();//do not track changes
if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()//health for catalog
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);//health for postgresql

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(opt =>{});//all configs by default
app.UseHealthChecks("/health",
    new HealthCheckOptions //for json response and additional entries
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.Run();

using System.Reflection;
using Xurmo.Api.Extensions;
using Xurmo.Api.Middleware;
using Xurmo.Common.Presentation.Endpoints;
using Xurmo.Modules.Catalogs.Infrastructure;
using Xurmo.Common.Application;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

Assembly[] moduleApplicationAssemblies = [
    Xurmo.Modules.Catalogs.Application.AssemblyReference.Assembly];

builder.Services.AddApplication(moduleApplicationAssemblies);

builder.Configuration.AddModuleConfiguration(["catalogs"]);

builder.Services.AddCatalogsModule(builder.Configuration);


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseLogContext();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.MapEndpoints();

app.Run();

public partial class Program;

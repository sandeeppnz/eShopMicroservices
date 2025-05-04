
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

// Service to the container
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddMarten(opt => {
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddCarter();
builder.Services.AddValidatorsFromAssembly(assembly);

var app = builder.Build();

//Configure HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(e =>
{
    e.Run(async context =>
    {
        var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (ex == null)
        {
            return;
        }

        var problemDetails = new ProblemDetails
        {
            Title = ex.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = ex.StackTrace
        };

        var logger = context.RequestServices.GetService<ILogger<Program>>();
        logger?.LogError(ex, ex.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.Run();

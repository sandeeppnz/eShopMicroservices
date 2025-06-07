using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.PermitLimit = 5; // Maximum number of requests
        options.Window = TimeSpan.FromSeconds(10); // Time window for the limit
    });
});

var app = builder.Build();


// Configure HTTP request pipeline
app.UseRateLimiter();
app.MapReverseProxy();


app.Run();

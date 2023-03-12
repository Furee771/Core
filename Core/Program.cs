using Core;

var builder = WebApplication.CreateBuilder(args);

var serviceConfig = builder.Configuration;
builder.Services.Configure<FruitOptions>(serviceConfig.GetSection("Fruit"));


var app = builder.Build();

app.Logger.LogDebug("Pipeline configuration starting");


app.MapGet("/config", async (HttpContext context, IConfiguration config) =>
{
    string defaultDebug = config["Logging:LogLevel:Default"];
    await context.Response.WriteAsync(defaultDebug);

    string environment = config["ASPNETCORE_ENVIRONMENT"];
    await context.Response.WriteAsync(environment);

    if (app.Environment.IsDevelopment())
    {
        await context.Response.WriteAsync("IsDevelopment");
    }
});

app.UseMiddleware<FruitMiddleware>();

app.MapGet("/", () => "Hello Wrold!");

app.UseStaticFiles();

app.Run();
